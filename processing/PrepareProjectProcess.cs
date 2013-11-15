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
        public PrepareProjectProcess(params IProcess[] dependencies)
            : base("Projekt initialisieren", dependencies)
        { }

        protected override void Work()
        {
            PrepareProjectDirectory();
            CheckTools();
        }

        private void PrepareProjectDirectory()
        {
            var workDir = Project.GetWorkingDirectory();
            if (!Directory.Exists(Project.OutputDir))
            {
                WorkItem = "Ausgabeverzeichnis erstellen";
                Directory.CreateDirectory(Project.OutputDir);
            }
            if (Setup.RejectExistingIntermediates && Directory.Exists(workDir))
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

        private void CheckTools()
        {
            WorkItem = "Überprüfe Hilfsprogramme";
            foreach (var tt in ToolProvider.ToolTypes)
            {
                var tool = (ToolBase)ToolProvider.Create(tt);
                OnProgress(string.Format("Überprüfe {0}", tool.Name));
                if (!tool.CheckTool())
                {
                    throw new ApplicationException(string.Format("Das Hilfsprogramm {0} ist nicht verfügbar.", tool.Name));
                }
            }
        }
    }
}
