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

        private static string BuildArguments(string source, string target)
        {
            return string.Format("-v repeat+info -i \"{0}\" -n -vn -ac 1 -ar 16000 -acodec pcm_s16le \"{1}\"",
                source, target);
        }

        public bool ExtractAudio(string sourcePath, string targetPath,
            Action<float> progressHandler)
        {
            errors = new List<string>();
            duration = TimeSpan.Zero;
            var pi = new ProcessStartInfo(GetAbsoluteToolPath(), BuildArguments(sourcePath, targetPath));
            pi.RedirectStandardInput = false;
            pi.RedirectStandardOutput = true;
            pi.RedirectStandardError = true;
            pi.UseShellExecute = false;
            pi.CreateNoWindow = true;
            LogProcessStart(pi);
            var p = Process.Start(pi);
            p.PriorityClass = ProcessPriorityClass.BelowNormal;
            Task.Run(() => RunErrorReader(p.StandardError, progressHandler));
            p.WaitForExit();
            return p.ExitCode == 0 && errors.Count == 0 && File.Exists(targetPath);
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

        private TimeSpan GetTimeValue(Match match)
        {
            var h = int.Parse(match.Groups[1].Value);
            var m = int.Parse(match.Groups[2].Value);
            var s = int.Parse(match.Groups[3].Value);
            var ms = int.Parse(match.Groups[4].Value);
            return new TimeSpan(0, h, m, s, ms);
        }
    }
}
