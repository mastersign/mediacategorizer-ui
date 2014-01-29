using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace de.fhb.oll.mediacategorizer.tools
{
    abstract class ToolBase
    {
        private static readonly List<Process> PROCESSES = new List<Process>();

        protected void RegisterProcess(Process p)
        {
            if (p.HasExited) return;
            lock (PROCESSES)
            {
                p.Exited += ProcessExitedHandler;
                PROCESSES.Add(p);
            }
        }

        private static void ProcessExitedHandler(object sender, EventArgs e)
        {
            var p = (Process) sender;
            lock (PROCESSES)
            {
                PROCESSES.Remove(p);
            }
        }

        public static void KillRunningToolProcesses()
        {
            Process[] processes;
            lock (PROCESSES)
            {
                processes = PROCESSES.ToArray();
            }
            foreach (var p in processes) p.Kill();
        }

        private readonly ILogWriter logWriter;

        public string Name { get; protected set; }

        public string ToolPath { get; private set; }

        public string GetAbsoluteToolPath()
        {
            return Path.IsPathRooted(ToolPath)
                ? ToolPath
                : Path.Combine(
                    Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath),
                    ToolPath);
        }

        protected ToolBase(ILogWriter logWriter, string toolPath)
        {
            this.logWriter = logWriter;
            ToolPath = toolPath;
            Name = Path.GetFileName(toolPath);
        }

        public virtual bool CheckTool()
        {
            return File.Exists(ToolPath);
        }

        protected void Log(string line)
        {
            logWriter.Log(Name, line);
        }

        protected void LogProcessStart(ProcessStartInfo pi)
        {
            Log(string.Format("{0} {1}", pi.FileName, pi.Arguments));
        }
    }
}
