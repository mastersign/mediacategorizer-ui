using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            OnProgress(1, "abgeschlossen");
        }

        private void PrepareProjectDirectory()
        {
            if (!Directory.Exists(Project.OutputDir))
            {
                WorkItem = "Ausgabeverzeichnis erstellen";
                Directory.CreateDirectory(Project.OutputDir);
            }
            if (!Directory.Exists(Project.GetWorkingDirectory()))
            {
                WorkItem = "Arbeitsverzeichnis erstellen";
                Directory.CreateDirectory(Project.GetWorkingDirectory());
            }
        }

        private void CheckTools()
        {
            WorkItem = "Überprüfe Hilfsprogramme";
            foreach (var tt in ToolProvider.ToolTypes)
            {
                // TODO build and provide distillery.jar
                if (tt == typeof(DistilleryTool)) continue;

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
