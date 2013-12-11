using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.settings;
using Microsoft.Win32;

namespace de.fhb.oll.mediacategorizer.tools
{
    class DistilleryTool : ToolBase
    {
        private readonly Setup setup;
        private readonly string javaPath;

        private const float ANALYSIS_PART = 0.33f;

        private readonly List<string> workingTasks = new List<string>();
        private int totalAnalysisSteps;
        private int currentAnalysisStep;
        private readonly Dictionary<string, Tuple<int, int>> taskStates = new Dictionary<string, Tuple<int, int>>();

        private static readonly Regex TASK_GROUP_REGEX = new Regex(@"TASKGROUP\s+(.+)\s+\[(\d+)\]");
        private static readonly Regex TASK_END_REGEX = new Regex(@"TASK_END\s+(.+)$");
        private static readonly Regex TASK_GROUP_END_REGEX = new Regex(@"TASKGROUP_END\s+(.+)$");
        private static readonly Regex PIPELINE_REGEX = new Regex(@"PIPELINE\s+(.+)\s+\[(\d+)\]");
        private static readonly Regex PIPELINE_STEP_REGEX = new Regex(@"PIPELINE_STEP\s+(.+)\s+(\d+)");

        public DistilleryTool(ILogWriter logWriter, Setup setup)
            : base(logWriter, setup.Distillery)
        {
            Name = "distillery";
            this.setup = setup;
            javaPath = FindJava();
        }

        public bool RunDistillery(string jobFile, Action<string> workItemHandler,
            Action<string> messageHandler, Action<float> progressHandler,
            Action<string> errorHandler)
        {
            var arguments = string.Format("-jar \"{0}\" \"{1}\"", GetAbsoluteToolPath(), jobFile);
            var pi = new ProcessStartInfo(javaPath, arguments);
            pi.CreateNoWindow = true;
            pi.RedirectStandardOutput = true;
            pi.RedirectStandardError = true;
            pi.UseShellExecute = false;
            LogProcessStart(pi);
            var p = Process.Start(pi);
            RegisterProcess(p);
            p.PriorityClass = ProcessPriorityClass.BelowNormal;
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
                Log(l);
                if (!l.StartsWith("#"))
                {
                    Debug.WriteLine("distillery out: " + l);
                }
                if (l.StartsWith("# BEGIN ") && l.EndsWith("..."))
                {
                    ProcessBeginMessage(l, messageHandler);
                }
                else if (l.StartsWith("# END "))
                {
                    ProcessEndMessage(l, messageHandler);
                }
                else if (l.StartsWith("# TASKGROUP "))
                {
                    ProcessTaskGroupMessage(l, progressHandler);
                }
                else if (l.StartsWith("# TASK_END "))
                {
                    ProcessTaskEndMessage(l, progressHandler);
                }
                else if (l.StartsWith("# TASKGROUP_END "))
                {
                    ProcessTaskGroupEndMessage(l, progressHandler);
                }
                else if (l.StartsWith("# PIPELINE "))
                {
                    ProcessPipelineAnalysisMessage(l, progressHandler);
                }
                else if (l.StartsWith("# PIPELINE_STEP "))
                {
                    ProcessPipelineStepMessage(l, progressHandler);
                }
                else
                {
                    messageHandler(l.Substring(2));
                }
            }
        }

        private void ProcessBeginMessage(string line, Action<string> messageHandler)
        {
            var taskName = line.Substring(8, line.Length - 11);
            workingTasks.Add(taskName);
            messageHandler(workingTasks.Count > 0
                ? workingTasks[workingTasks.Count - 1]
                : null);
        }

        private void ProcessEndMessage(string line, Action<string> messageHandler)
        {
            var pos = line.LastIndexOf(" after ");
            if (pos < 0) return;
            var taskName = line.Substring(8, pos - 8);
            var taskId = workingTasks.LastIndexOf(taskName);
            if (taskId >= 0)
            {
                workingTasks.RemoveAt(taskId);
                messageHandler(workingTasks.Count > 0
                    ? workingTasks[workingTasks.Count - 1]
                    : null);
            }
        }

        private void ProcessTaskGroupMessage(string line, Action<float> progressHandler)
        {
            var match = TASK_GROUP_REGEX.Match(line);
            if (!match.Success) return;
            var name = match.Groups[1].Value;
            var taskCnt = int.Parse(match.Groups[2].Value);
            taskStates[name] = Tuple.Create(taskCnt, 0);
            UpdateTaskGroupProgress(progressHandler);
        }

        private void ProcessTaskEndMessage(string line, Action<float> progressHandler)
        {
            var match = TASK_END_REGEX.Match(line);
            if (!match.Success) return;
            var name = match.Groups[1].Value;
            Tuple<int, int> taskState;
            if (!taskStates.TryGetValue(name, out taskState)) return;
            taskStates[name] = Tuple.Create(taskState.Item1, taskState.Item2 + 1);
            UpdateTaskGroupProgress(progressHandler);
        }

        private void ProcessTaskGroupEndMessage(string line, Action<float> progressHandler)
        {
            var match = TASK_GROUP_END_REGEX.Match(line);
            if (!match.Success) return;
            var name = match.Groups[1].Value;
            Tuple<int, int> taskState;
            if (!taskStates.TryGetValue(name, out taskState)) return;
            taskStates[name] = Tuple.Create(taskState.Item1, taskState.Item1);
            UpdateTaskGroupProgress(progressHandler);
        }

        private void UpdateTaskGroupProgress(Action<float> progressHandler)
        {
            var taskCnt = taskStates.Sum(t => t.Value.Item1);
            progressHandler(taskCnt > 0
                ? ANALYSIS_PART + (float)taskStates.Sum(t => t.Value.Item2) / taskCnt * (1 - ANALYSIS_PART)
                : ANALYSIS_PART);
        }

        private void ProcessPipelineAnalysisMessage(string line, Action<float> progressHandler)
        {
            var match = PIPELINE_REGEX.Match(line);
            if (!match.Success) return;
            var name = match.Groups[1].Value;
            if (name == "Analysis")
            {
                totalAnalysisSteps = int.Parse(match.Groups[2].Value);
                currentAnalysisStep = 0;
            }
            UpdateAnalysisProgress(progressHandler);
        }

        private void ProcessPipelineStepMessage(string line, Action<float> progressHandler)
        {
            var match = PIPELINE_STEP_REGEX.Match(line);
            if (!match.Success) return;
            var name = match.Groups[1].Value;
            if (name == "Analysis")
            {
                currentAnalysisStep += 1;
            }
            UpdateAnalysisProgress(progressHandler);
        }

        private void UpdateAnalysisProgress(Action<float> progressHandler)
        {
            progressHandler(ANALYSIS_PART * currentAnalysisStep / totalAnalysisSteps);
        }

        private void ProcessError(TextReader r, Action<string> workItemHandler,
            Action<string> messageHandler, Action<float> progressHandler,
            Action<string> errorHandler)
        {
            string l;
            while ((l = r.ReadLine()) != null)
            {
                Log(l);
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
