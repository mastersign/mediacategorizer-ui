using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    class MediaEncodingProcess : MultiTaskProcessBase
    {
        public MediaEncodingProcess(ProcessChain chain, params IProcess[] dependencies)
            : base(chain, "Mediendateien vorbereiten", dependencies)
        {
            ProgressWeight = 20;
        }

        private FfmpegTool GetFfmpegTool()
        {
            return (FfmpegTool)ToolProvider.Create(Chain, typeof(FfmpegTool));
        }

        protected override void Work()
        {
            if (Project.Configuration.SkipMediaCopy) return;

            OnProgress("Mediendateien werden für das Abspielen im Browser vorbereitet...");
            var media = Project.GetMedia().ToArray();
            RunTasks(media.Select(m => (ProcessTask)((pH, eH) => ProcessMedia(m, pH, eH))).ToArray());
        }

        private void ProcessMedia(Media m, Action<float> progressHandler, Action<string> errorHandler)
        {
            OnProgress(m.MediaFile);
            if (m.MediaFile == null || !File.Exists(m.MediaFile))
            {
                errorHandler("Mediendatei wurde nicht gefunden: " + m.MediaFile);
                return;
            }
            var audioExts = Setup.GetAudioFileExtensions();
            var videoExts = Setup.GetVideoFileExtensions();
            m.MediaType = MediaType.Unknown;
            var sourceExt = Path.GetExtension(m.MediaFile).TrimStart('.').ToLowerInvariant();
            if (audioExts.Contains(sourceExt)) m.MediaType = MediaType.Audio;
            if (videoExts.Contains(sourceExt)) m.MediaType = MediaType.Video;

            if (m.MediaType == MediaType.Video && Project.Configuration.VideoToAudio)
            {
                m.MediaType = MediaType.Audio;
            }

            var baseTargetPath = Path.Combine(Project.GetWorkingDirectory(), m.Id + ".");

            if (Project.Configuration.UseTranscoding || m.MediaType == MediaType.Unknown)
            {
                switch (m.MediaType)
                {
                    case MediaType.Audio:
                        TranscodeAudio(m, progressHandler, errorHandler, baseTargetPath);
                        break;
                    case MediaType.Video:
                        TranscodeVideo(m, progressHandler, errorHandler, baseTargetPath);
                        break;
                }
            }
            else
            {
                m.EncodedMediaFiles.Add(new MediaFile { Path = m.MediaFile, MimeType = GetMimeType(m.MediaType, sourceExt) });
            }
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
                        case "ogg":
                            return "audio/ogg";
                        default:
                            return "audio/unknown";
                    }
                case MediaType.Video:
                    switch (ext)
                    {
                        case "mp4":
                            return "video/mp4";
                        case "ogv":
                            return "video/ogg";
                        case "webm":
                            return "video/webm";
                        default:
                            return "video/unknown";
                    }
                default:
                    return "application/octet-stream";
            }
        }

        private void TranscodeAudio(Media m, Action<float> progressHandler, Action<string> errorHandler, string baseTargetPath)
        {
            var cfg = Project.Configuration;
            var cnt =
                (cfg.AudioTranscodeMP3 ? 1 : 0) +
                (cfg.AudioTranscodeOGG ? 1 : 0);
            int[] no = { 0 };
            var audioProgressHandler = (Action<float>)(p => progressHandler((no[0] + p) / cnt));
            var audioHandler = (Action<FfmpegTool.AudioFormat, AudioEncodingParameter>)((f, p) =>
            {
                var ext = GetExtension(f);
                var targetPath = baseTargetPath + ext;
                if (!File.Exists(targetPath))
                {
                    var res = GetFfmpegTool().TranscodeAudio(
                        m.MediaFile, targetPath, f, p.AudioBitrate, p.JoinChannels, audioProgressHandler);
                    if (!res)
                    {
                        errorHandler("Transkodierung von '" + m.MediaFile + "' in das Audio-Format " + f +
                                     " fehlgeschlagen.");
                    }
                }
                m.EncodedMediaFiles.Add(new MediaFile
                {
                    Path = targetPath,
                    MimeType = GetMimeType(MediaType.Audio, ext),
                });
                no[0]++;
            });
            if (cfg.AudioTranscodeMP3) audioHandler(FfmpegTool.AudioFormat.Mp3, cfg.AudioParameterMP3);
            if (cfg.AudioTranscodeOGG) audioHandler(FfmpegTool.AudioFormat.Ogg, cfg.AudioParameterOGG);
        }

        private static string GetExtension(FfmpegTool.AudioFormat format)
        {
            switch (format)
            {
                case FfmpegTool.AudioFormat.Mp3:
                    return "mp3";
                case FfmpegTool.AudioFormat.Ogg:
                    return "ogg";
                default:
                    throw new ArgumentOutOfRangeException("format");
            }
        }

        private void TranscodeVideo(Media m, Action<float> progressHandler, Action<string> errorHandler, string baseTargetPath)
        {
            var cfg = Project.Configuration;
            var cnt =
                (cfg.VideoTranscodeH264 ? 1 : 0) +
                (cfg.VideoTranscodeOGG ? 1 : 0) +
                (cfg.VideoTranscodeWebM ? 1 : 0);
            int[] no = { 0 };
            var videoProgressHandler = (Action<float>)(p => progressHandler((no[0] + p) / cnt));
            var processHandler = (Action<FfmpegTool.VideoFormat, VideoEncodingParameter>)((f, p) =>
            {
                var ext = GetExtension(f);
                var targetPath = baseTargetPath + ext;
                if (!File.Exists(targetPath))
                {
                    var res = GetFfmpegTool().TranscodeVideo(
                        m.MediaFile, targetPath, f, cfg.VideoWidth, p.VideoBitrate, p.AudioBitrate, p.JoinChannels,
                        videoProgressHandler);
                    if (!res)
                    {
                        errorHandler("Transkodierung von '" + m.MediaFile + "' in das Video-Format " + f +
                                     " fehlgeschlagen.");
                    }
                }
                m.EncodedMediaFiles.Add(new MediaFile
                {
                    Path = targetPath,
                    MimeType = GetMimeType(MediaType.Video, ext),
                });
                no[0]++;
            });
            if (cfg.VideoTranscodeH264) processHandler(FfmpegTool.VideoFormat.Mp4, cfg.VideoParameterH264);
            if (cfg.VideoTranscodeOGG) processHandler(FfmpegTool.VideoFormat.Ogg, cfg.VideoParameterOGG);
            if (cfg.VideoTranscodeWebM) processHandler(FfmpegTool.VideoFormat.WebM, cfg.VideoParameterWebM);
        }

        private static string GetExtension(FfmpegTool.VideoFormat format)
        {
            switch (format)
            {
                case FfmpegTool.VideoFormat.Mp4:
                    return "mp4";
                case FfmpegTool.VideoFormat.Ogg:
                    return "ogv";
                case FfmpegTool.VideoFormat.WebM:
                    return "webm";
                default:
                    throw new ArgumentOutOfRangeException("format");
            }
        }
    }
}
