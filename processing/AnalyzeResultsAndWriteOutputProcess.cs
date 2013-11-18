using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.edn;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    class AnalyzeResultsAndWriteOutputProcess : ProcessBase
    {
        public AnalyzeResultsAndWriteOutputProcess(params IProcess[] dependencies)
            : base("Analysieren und Ergebnisse speichern", dependencies)
        {
            ProgressWeight = 20;
        }

        private DistilleryTool GetDistilleryTool()
        {
            return (DistilleryTool)ToolProvider.Create(typeof(DistilleryTool));
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
                Project.WriteTo(ednW);
            }

            OnProgress("Analyse starten...");
            var distillery = GetDistilleryTool();
            distillery.RunDistillery(jobFile, wi => { WorkItem = wi; }, OnProgress, OnProgress, OnError);

    }
}
