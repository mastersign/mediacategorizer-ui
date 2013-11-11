using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    class AudioExtractionProcess : ProcessBase
    {
        private FfmpegTool ffmpeg;

        private Queue<Action> taskQueue;
        private readonly AutoResetEvent finishedEvent = new AutoResetEvent(false);

        public AudioExtractionProcess(params IProcess[] dependencies)
            : base("Extraktion der Audiospur", dependencies)
        { }

        private string BuildAudioPath(Media media)
        {
            return Path.Combine(Project.GetWorkingDirectory(), string.Format("{0}.wav", media.Id));
        }

        protected override void Work()
        {
            InitializeTool();
            var media = Project.Media.ToArray();
            taskQueue = new Queue<Action>();
            for (var i = 0; i < media.Length; i++)
            {
                var i_ = i;
                taskQueue.Enqueue(() => ProcessMedia(media[i_], media.Length, i_));
            }
            ProcessNextItem();
            finishedEvent.WaitOne();
            if (ErrorMessage == null)
            {
                WorkItem = null;
                OnProgress(1, "abgeschlossen");
            }
        }

        private void InitializeTool()
        {
            if (ffmpeg == null)
            {
                ffmpeg = (FfmpegTool)ToolProvider.Create(typeof(FfmpegTool));
            }
        }

        private void ProcessNextItem()
        {
            if (taskQueue.Count == 0)
            {
                finishedEvent.Set();
            }
            else
            {
                Task.Run(taskQueue.Dequeue());
            }
        }

        private void ProcessMedia(Media m, int total, int no)
        {
            WorkItem = m.Name;
            m.AudioFile = BuildAudioPath(m);
            OnProgress(CalculateProgress(total, no, 0), "Audiodaten als 16Bit PCM Wave Mono speichern...");
            if (File.Exists(m.AudioFile))
            {
                ProcessNextItem();
                return;
            }
            var success = ffmpeg.ExtractAudio(m.MediaFile, m.AudioFile, p => OnProgress(CalculateProgress(total, no, p)));
            if (success)
            {
                ProcessNextItem();
            }
            else
            {
                OnError("ffmpeg wurde mit einem Fehler beendet");
                finishedEvent.Set();
            }
        }
    }
}
