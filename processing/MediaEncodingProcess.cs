using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.model;

namespace de.fhb.oll.mediacategorizer.processing
{
    class MediaEncodingProcess : MultiTaskProcessBase
    {
        public MediaEncodingProcess(ProcessChain chain, params IProcess[] dependencies)
            : base(chain, "Mediendateien vorbereiten", dependencies)
        { }

        protected override void Work()
        {
            if (Project.Configuration.SkipMediaCopy) return;

            OnProgress("Mediendateien werden für das Abspielen im Browser vorbereitet...");
            var media = Project.GetMedia().ToArray();
            RunTasks(media.Select(m => (ProcessTask)((pH, eH) => ProcessMedia(m, pH, eH))).ToArray());
        }

        private static string GetMimeType(MediaType type, string ext)
        {
            switch (type)
            {
                case MediaType.Audio:
                    switch (ext)
                    {
                        case "wav":
                            return "audio/wav";
                        case "mp3":
                            return "audio/mpeg";
                        default:
                            return "audio/unknown";
                    }
                case MediaType.Video:
                    switch (ext)
                    {
                        case "mp4":
                            return "video/mp4";
                        default:
                            return "video/unknown";
                    }
                default:
                    return "application/octet-stream";
            }
        }

        private void ProcessMedia(Media m, Action<float> progressHandler, Action<string> errorHandler)
        {
            if (m.MediaFile == null || !File.Exists(m.MediaFile))
            {
                errorHandler("Mediendatei wurde nicht gefunden: " + m.MediaFile);
                return;
            }
            var audioExts = Setup.GetAudioFileExtensions();
            var videoExts = Setup.GetVideoFileExtensions();
            var ext = Path.GetExtension(m.MediaFile).TrimStart('.').ToLowerInvariant();
            m.MediaType = MediaType.Unknown;
            if (audioExts.Contains(ext)) m.MediaType = MediaType.Audio;
            if (videoExts.Contains(ext)) m.MediaType = MediaType.Video;

            m.EncodedMediaFiles.Add(new MediaFile { Path = m.MediaFile, MimeType = GetMimeType(m.MediaType, ext) });
        }
    }
}
