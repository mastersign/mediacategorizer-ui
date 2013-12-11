using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using de.fhb.oll.mediacategorizer.edn;
using de.fhb.oll.mediacategorizer.settings;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    class AnalyzeResultsAndWriteOutputProcess : ProcessBase
    {
        public AnalyzeResultsAndWriteOutputProcess(ProcessChain chain, params IProcess[] dependencies)
            : base(chain, "Analysieren und Ergebnisse speichern", dependencies)
        {
            ProgressWeight = 20;
        }

        private DistilleryTool GetDistilleryTool()
        {
            return (DistilleryTool)ToolProvider.Create(Chain, typeof(DistilleryTool));
        }

        private string BuildJobFilePath()
        {
            return Path.Combine(Project.GetWorkingDirectory(), "job.edn");
        }

        protected override void Work()
        {
            var jobFile = BuildJobFilePath();
            OnProgress("Projekt kodieren...");
            using (var w = new StreamWriter(jobFile))
            {
                var ednW = new EdnWriter(w);
                Project.Configuration.VolatileProperties["parallel-proc"] = Setup.Parallelization != ParallelizationMode.None;
                Project.WriteTo(ednW);
            }

            OnProgress("Analyse starten...");
            var distillery = GetDistilleryTool();
            var state = distillery.RunDistillery(jobFile, wi => { WorkItem = wi; }, OnProgress, OnProgress, OnError);
            if (!state)
            {
                OnError("Der Java-Prozess wurde mit einem Fehler beendet.");
            }
            else if (Project.Configuration.ShowResult)
            {
                var resultFileToShow = Path.Combine(Project.GetOutputDir(),
                    Project.Configuration.VisualizeResult
                        ? "index.html"
                        : Project.ResultFile);
                if (File.Exists(resultFileToShow)) Process.Start(resultFileToShow);
            }
        }
    }
}
