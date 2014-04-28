using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    class AudioExtractionProcess : MultiTaskProcessBase
    {
        public AudioExtractionProcess(ProcessChain chain, params IProcess[] dependencies)
            : base(chain, "Audiospur extrahieren", dependencies)
        {
            ProgressWeight = 10;
        }

        private FfmpegTool GetFfmpegTool()
        {
            return (FfmpegTool)ToolProvider.Create(Chain, typeof(FfmpegTool));
        }

        protected override void Work()
        {
            OnProgress("Audiodaten als 16Bit PCM Wave Mono speichern...");
            var media = Project.GetMedia().ToArray();
            RunTasks(media.Select(m => (ProcessTask)((pH, eH) => ProcessMedia(m, pH, eH))).ToArray());
        }

        private string BuildAudioPath(Media media)
        {
            return Path.Combine(Project.GetWorkingDirectory(), string.Format("{0}.wav", media.Id));
        }

        private void ProcessMedia(Media m, Action<float> progressHandler, Action<string> errorHandler)
        {
            m.AudioFile = BuildAudioPath(m);
            if (!File.Exists(m.AudioFile))
            {
                var ffmpeg = GetFfmpegTool();
                if (!ffmpeg.ExtractAudio(m.MediaFile, m.AudioFile, progressHandler))
                {
                    errorHandler("FFmpeg wurde mit einem Fehler beendet");
                }
            }
            else
            {
                progressHandler(1);
            }
        }
    }
}
