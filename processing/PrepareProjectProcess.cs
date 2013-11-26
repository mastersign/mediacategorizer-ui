using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    class PrepareProjectProcess : ProcessBase
    {
        public PrepareProjectProcess(ProcessChain chain, params IProcess[] dependencies)
            : base(chain, "Projekt initialisieren", dependencies)
        {
            ProgressWeight = 1;
        }

        protected override void Work()
        {
            PrepareProjectDirectory();
            InitializeLogWriter();
            CheckTools();
        }

        private void PrepareProjectDirectory()
        {
            var workDir = Project.GetWorkingDirectory();
            if (!Directory.Exists(Project.GetOutputDir()))
            {
                WorkItem = "Ausgabeverzeichnis erstellen";
                Directory.CreateDirectory(Project.GetOutputDir());
            }
            if (Project.Configuration.RejectExistingIntermediates && Directory.Exists(workDir))
            {
                OnProgress("Arbeitsverzeichnis aufräumen");
                foreach (var dir in Directory.GetDirectories(workDir))
                {
                    Directory.Delete(dir, true);
                }
                foreach (var file in Directory.GetFiles(workDir))
                {
                    File.Delete(file);
                }
            }
            if (!Directory.Exists(workDir))
            {
                WorkItem = "Arbeitsverzeichnis erstellen";
                Directory.CreateDirectory(workDir);
            }
        }

        private void InitializeLogWriter()
        {
            var fileName = string.Format("{0:yyyy-MM-dd_HH-mm-ss}.log", DateTime.Now);
            var filePath = Path.Combine(Project.GetWorkingDirectory(), fileName);
            var s = File.Open(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
            var tw = new StreamWriter(s, Encoding.UTF8, 1024, false);
            Chain.InitializeLogWriter(new LogWriter(tw));
        }

        private void CheckTools()
        {
            WorkItem = "Überprüfe Hilfsprogramme";
            foreach (var tt in ToolProvider.ToolTypes)
            {
                var tool = (ToolBase)ToolProvider.Create(Chain, tt);
                OnProgress(string.Format("Überprüfe {0}", tool.Name));
                if (!tool.CheckTool())
                {
                    throw new ApplicationException(string.Format("Das Hilfsprogramm {0} ist nicht verfügbar.", tool.Name));
                }
            }
        }
    }
}
