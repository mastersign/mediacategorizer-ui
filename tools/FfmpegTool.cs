using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.settings;

namespace de.fhb.oll.mediacategorizer.tools
{
    class FfmpegTool : ToolBase
    {
        private TimeSpan duration;
        private static readonly Regex DURATION_REGEX = new Regex(@"Duration: (\d+):(\d\d):(\d\d)\.(\d+)");
        private static readonly Regex PROGRESS_REGEX = new Regex(@"size=.*time=(\d+):(\d\d):(\d\d)\.(\d+)");
        private static readonly Regex ERROR_REGEX = new Regex(@"ERROR|No such file or directory", RegexOptions.IgnoreCase);

        private List<string> errors;

        public FfmpegTool(ILogWriter logWriter, Setup setup)
            : base(logWriter, setup.Ffmpeg)
        { }

        private static string BuildArguments(string source, string target, 
            string optionFormat, params object[] optionArgs)
        {
            return string.Format("-v repeat+info -n -i \"{0}\" {2} \"{1}\"", 
                source, target, string.Format(optionFormat, optionArgs));
        }

        private static string BuildExtractAudioArguments(string source, string target)
        {
            return BuildArguments(source, target, "-vn -ac 1 -ar 16000 -acodec pcm_s16le");
        }

        private static string BuildTranscodeVideoArguments(string source, string target, 
            VideoFormat format, int maxWidth, int videoBitrate, int audioBitrate, bool mono)
        {
            switch (format)
            {
                case VideoFormat.Mp4:
                    return BuildArguments(source, target,
                        "-b:v {0}k -vcodec libx264 -b:a {1}k -vf \"scale='min(iw,{2})':-1\"{3}",
                        videoBitrate, audioBitrate, maxWidth, mono ? " -ac 1" : "");
                case VideoFormat.Ogg:
                    return BuildArguments(source, target, 
                        "-b:v {0}k -vcodec libtheora -acodec libvorbis -b:a {1}k -vf \"scale='min(iw,{2})':-1\"{3}",
                        videoBitrate, audioBitrate, maxWidth, mono ? " -ac 1" : "");
                case VideoFormat.WebM:
                    return BuildArguments(source, target, 
                        "-b:v {0}k -vcodec libvpx -acodec libvorbis -b:a {1}k -vf \"scale='min(iw,{2})':-1\"{3} -f webm",
                        videoBitrate, audioBitrate, maxWidth, mono ? " -ac 1" : "");
                default:
                    throw new ArgumentOutOfRangeException("format");
            }
        }

        private static string BuildTranscodeAudioArguments(string source, string target,
            AudioFormat format, int audioBitrate, bool mono)
        {
            switch (format)
            {
                case AudioFormat.Mp3:
                    return BuildArguments(source, target, 
                        "-vn -b:a {0}k {1} -acodec libmp3lame",
                        audioBitrate, mono ? " -ac 1" : "");
                case AudioFormat.Ogg:
                    return BuildArguments(source, target, 
                        "-vn -b:a {0}k {1} -acodec libvorbis",
                        audioBitrate, mono ? " -ac 1" : "");
                default:
                    throw new ArgumentOutOfRangeException("format");
            }
        }

        private bool Transcode(string arguments, Action<float> progressHandler)
        {
            errors = new List<string>();
            duration = TimeSpan.Zero;
            var pi = new ProcessStartInfo(GetAbsoluteToolPath(), arguments);
            pi.RedirectStandardInput = false;
            pi.RedirectStandardOutput = true;
            pi.RedirectStandardError = true;
            pi.UseShellExecute = false;
            pi.CreateNoWindow = true;
            LogProcessStart(pi);
            var p = Process.Start(pi);
            RegisterProcess(p);
            p.PriorityClass = ProcessPriorityClass.BelowNormal;
            Task.Run(() => RunErrorReader(p.StandardError, progressHandler));
            p.WaitForExit();
            return p.ExitCode == 0 && errors.Count == 0;
        }

        public bool ExtractAudio(string sourcePath, string targetPath,
            Action<float> progressHandler)
        {
            var args = BuildExtractAudioArguments(sourcePath, targetPath);
            return Transcode(args, progressHandler) && File.Exists(targetPath);
        }

        public bool TranscodeVideo(string sourcePath, string targetPath,
            VideoFormat format, int maxWidth, int videoBitrate, int audioBitrate, bool mono,
            Action<float> progressHandler)
        {
            var args = BuildTranscodeVideoArguments(sourcePath, targetPath, format,maxWidth, videoBitrate, audioBitrate, mono);
            return Transcode(args, progressHandler) && File.Exists(targetPath);
        }

        public bool TranscodeAudio(string sourcePath, string targetPath,
            AudioFormat format, int audioBitrate, bool mono,
            Action<float> progressHandler)
        {
            var args = BuildTranscodeAudioArguments(sourcePath, targetPath, format, audioBitrate, mono);
            return Transcode(args, progressHandler) && File.Exists(targetPath);
        }

        private void RunErrorReader(TextReader sr, Action<float> progressHandler)
        {
            string l;
            while ((l = sr.ReadLine()) != null)
            {
                Log(l);
                ProcessDuration(l);
                ProcessProgress(progressHandler, l);
                ProcessErrors(l);
            }
        }

        private void ProcessDuration(string l)
        {
            var durationMatch = DURATION_REGEX.Match(l);
            if (durationMatch.Success)
            {
                duration = GetTimeValue(durationMatch);
            }
        }

        private void ProcessProgress(Action<float> progressHandler, string l)
        {
            var progressMatch = PROGRESS_REGEX.Match(l);
            if (duration > TimeSpan.Zero && progressMatch.Success)
            {
                var currentTime = GetTimeValue(progressMatch);
                progressHandler(Math.Max(0f, Math.Min((float)(currentTime.TotalSeconds / duration.TotalSeconds), 1f)));
            }
        }

        private void ProcessErrors(string l)
        {
            var errorMatch = ERROR_REGEX.Match(l);
            if (errorMatch.Success)
            {
                errors.Add(l);
            }
        }

        private static TimeSpan GetTimeValue(Match match)
        {
            var h = int.Parse(match.Groups[1].Value);
            var m = int.Parse(match.Groups[2].Value);
            var s = int.Parse(match.Groups[3].Value);
            var ms = int.Parse(match.Groups[4].Value);
            return new TimeSpan(0, h, m, s, ms);
        }

        public enum VideoFormat
        {
            Mp4,
            Ogg,
            WebM,
        }

        public enum AudioFormat
        {
            Mp3,
            Ogg,
        }
    }
}
