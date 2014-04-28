using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    class MediaInspectionProcess : MultiTaskProcessBase
    {

        public MediaInspectionProcess(ProcessChain chain, params IProcess[] dependencies)
            : base(chain, "Medien untersuchen", dependencies)
        {
            ProgressWeight = 3;
            AutoSetWorkItem = true;
        }

        private FfprobeTool GetFfprobe()
        {
            return (FfprobeTool)ToolProvider.Create(Chain, typeof(FfprobeTool));
        }

        protected override void Work()
        {
            OnProgress("Video- und Audiodatenströme untersuchen");
            var media = Project.GetMedia().ToArray();
            RunTasks(media.Select(m => (ProcessTask)((pH, eH) => ProcessMedia(m, pH, eH))).ToArray());
        }

        private void ProcessMedia(Media m, Action<float> progressHandler, Action<string> errorHandler)
        {
            var ffprobe = GetFfprobe();
            var info = ffprobe.GetMediaInfo(m.MediaFile);
            m.Duration = info.Duration.TotalSeconds;
            if (m.Duration <= 0.0)
            {
                Debug.WriteLine("The duration of media '" + m.Id + "' was determined as zero.", "WARNING");
            }
        }
    }
}
