using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    class MediaInspectionProcess : MultiTaskProcessBase
    {
        private FfprobeTool ffprobe;

        public MediaInspectionProcess(params IProcess[] dependencies)
            : base("Medien untersuchen", dependencies)
        {
            AutoSetWorkItem = true;
        }

        private void InitializeTool()
        {
            if (ffprobe == null)
            {
                ffprobe = (FfprobeTool)ToolProvider.Create(typeof(FfprobeTool));
            }
        }

        protected override void Work()
        {
            InitializeTool();
            OnProgress("Video- und Audiodatenströme untersuchen");
            var media = Project.Media.ToArray();
            RunTasks(media.Select(m => (ProcessTask)((pH, eH) => ProcessMedia(m, pH, eH))).ToArray());
        }

        private void ProcessMedia(Media m, Action<float> progressHandler, Action<string> errorHandler)
        {
            var info = ffprobe.GetMediaInfo(m.MediaFile);
            m.Duration = info.Duration.TotalSeconds;
        }
    }
}
