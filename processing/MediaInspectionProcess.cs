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

        public MediaInspectionProcess(params IProcess[] dependencies)
            : base("Medien untersuchen", dependencies)
        {
            AutoSetWorkItem = true;
        }

        private FfprobeTool GetFfprobe()
        {
            return (FfprobeTool)ToolProvider.Create(typeof(FfprobeTool));
        }

        protected override void Work()
        {
            OnProgress("Video- und Audiodatenströme untersuchen");
            var media = Project.Media.ToArray();
            RunTasks(media.Select(m => (ProcessTask)((pH, eH) => ProcessMedia(m, pH, eH))).ToArray());
        }

        private void ProcessMedia(Media m, Action<float> progressHandler, Action<string> errorHandler)
        {
            var ffprobe = GetFfprobe();
            var info = ffprobe.GetMediaInfo(m.MediaFile);
            m.Duration = info.Duration.TotalSeconds;
        }
    }
}
