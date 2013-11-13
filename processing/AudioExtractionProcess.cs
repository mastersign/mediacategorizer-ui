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
        private FfmpegTool ffmpeg;

        public AudioExtractionProcess(params IProcess[] dependencies)
            : base("Audiospur extrahieren", dependencies)
        { }

        private void InitializeTool()
        {
            if (ffmpeg == null)
            {
                ffmpeg = (FfmpegTool)ToolProvider.Create(typeof(FfmpegTool));
            }
        }

        protected override void Work()
        {
            InitializeTool();
            OnProgress("Audiodaten als 16Bit PCM Wave Mono speichern...");
            var media = Project.Media.ToArray();
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
