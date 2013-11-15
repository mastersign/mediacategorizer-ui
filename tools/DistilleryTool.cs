using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.settings;
using Microsoft.Win32;

namespace de.fhb.oll.mediacategorizer.tools
{
    class DistilleryTool : ToolBase
    {
        private readonly Setup setup;
        private readonly string javaPath;

        private List<string> workingTasks = new List<string>();

        public DistilleryTool(Setup setup)
            : base(setup.Distillery)
        {
            this.setup = setup;
            javaPath = FindJava();
        }

        public bool RunDistillery(string jobFile, Action<string> workItemHandler,
            Action<string> messageHandler, Action<float> progressHandler,
            Action<string> errorHandler)
        {
            var arguments = string.Format("-jar \"{0}\" \"{1}\"", ToolPath, jobFile);
            var pi = new ProcessStartInfo(javaPath, arguments);
            pi.CreateNoWindow = true;
            pi.RedirectStandardOutput = true;
            pi.RedirectStandardError = true;
            pi.UseShellExecute = false;
            var p = Process.Start(pi);
            Task.Run(() => ProcessOutput(p.StandardOutput, workItemHandler, messageHandler, progressHandler, errorHandler));
            Task.Run(() => ProcessError(p.StandardError, workItemHandler, messageHandler, progressHandler, errorHandler));
            p.WaitForExit();
            return p.ExitCode == 0;
        }

        private void ProcessOutput(TextReader r, Action<string> workItemHandler,
            Action<string> messageHandler, Action<float> progressHandler,
            Action<string> errorHandler)
        {
            string l;
            while ((l = r.ReadLine()) != null)
            {
                if (!l.StartsWith("#"))
                {
                    Debug.WriteLine("distillery out: " + l);
                }
                if (l.StartsWith("# BEGIN ") && l.EndsWith("..."))
                {
                    var taskName = l.Substring(8, l.Length - 11);
                    workingTasks.Add(taskName);
                    messageHandler(workingTasks.Count > 0
                        ? workingTasks[workingTasks.Count - 1]
                        : null);
                }
                else if (l.StartsWith("# END "))
                {
                    var pos = l.LastIndexOf(" after ");
                    if (pos < 0) continue;
                    var taskName = l.Substring(8, pos - 8);
                    var taskId = workingTasks.LastIndexOf(taskName);
                    if (taskId >= 0)
                    {
                        workingTasks.RemoveAt(taskId);
                        messageHandler(workingTasks.Count > 0
                            ? workingTasks[workingTasks.Count - 1]
                            : null);
                    }
                }
                else
                {
                    messageHandler(l.Substring(2));
                }
            }
        }

        private void ProcessError(TextReader r, Action<string> workItemHandler,
            Action<string> messageHandler, Action<float> progressHandler,
            Action<string> errorHandler)
        {
            string l;
            while ((l = r.ReadLine()) != null)
            {
                errorHandler(l);
                Debug.WriteLine("distillery err: " + l);
            }
        }

        #region JAVA detection

        private const int JAVA_MAJOR_VERSION = 1;
        private const int MIN_JAVA_MINOR_VERSION = 7;

        private string FindJava()
        {
            return FindJavaInSetup()
                ?? FindJavaInEnvVarJavaHome()
                ?? FindJavaInRegistry()
                ?? FindJavaInEnvVarPath();
        }

        private string FindJavaInSetup()
        {
            if (string.IsNullOrWhiteSpace(setup.JavaRuntime)) return null;
            Debug.WriteLine("JRE (Configuration): " + setup.JavaRuntime);
            return setup.JavaRuntime;
        }

        private static string FindJavaInRegistry()
        {
            var jreKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment");
            if (jreKey == null) return null;
            var version = jreKey.GetValue("CurrentVersion") as string;
            if (version == null) return null;
            var versionElements = version.Split('.');
            if (versionElements.Length < 2) return null;
            int majVersion, minVersion;
            if (!int.TryParse(versionElements[0], out majVersion) ||
                !int.TryParse(versionElements[1], out minVersion)) return null;
            if (majVersion != JAVA_MAJOR_VERSION ||
                minVersion < MIN_JAVA_MINOR_VERSION) return null;
            var jreVersionKey = jreKey.OpenSubKey(version);
            if (jreVersionKey == null) return null;
            var javaHome = jreVersionKey.GetValue("JavaHome") as string;
            if (javaHome == null || !Directory.Exists(javaHome)) return null;
            var javaPath = Path.Combine(javaHome, "bin", "java.exe");
            Debug.WriteLine("JRE (Registry): " + javaPath);
            return javaPath;
        }

        private static string FindJavaInEnvVarJavaHome()
        {
            var javaHome = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (javaHome == null) return null;
            if (!Directory.Exists(javaHome)) return null;
            var javaPath = Path.Combine(javaHome, "bin", "java.exe");
            Debug.WriteLine("JRE (JAVA_HOME): " + javaPath);
            return javaPath;
        }

        private static string FindJavaInEnvVarPath()
        {
            var envPath = Environment.GetEnvironmentVariable("PATH");
            if (envPath == null) return null;
            var envPaths = envPath.Split(new[] { Path.PathSeparator })
                .Select(Environment.ExpandEnvironmentVariables)
                .ToArray();
            foreach (var path in envPaths)
            {
                if ((Path.GetFileName(path) ?? "").ToLowerInvariant() == "java.exe" &&
                    File.Exists(path))
                {
                    Debug.WriteLine("JRE (PATH): " + path);
                    return path;
                }
                if (Directory.Exists(path))
                {
                    var javaPath = Path.Combine(path, "java.exe");
                    if (File.Exists(javaPath))
                    {
                        Debug.WriteLine("JRE (PATH): " + javaPath);
                        return javaPath;
                    }
                }
            }
            return null;
        }

        #endregion

        public override bool CheckTool()
        {
            return base.CheckTool()
                && File.Exists(javaPath);
        }
    }
}
