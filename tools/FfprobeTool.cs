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
    class FfprobeTool : ToolBase
    {
        private TimeSpan duration;
        private static readonly Regex DURATION_REGEX = new Regex(@"Duration: (\d+):(\d\d):(\d\d).(\d+)");
        private static readonly Regex ERROR_REGEX = new Regex(@"ERROR|No such file or directory", RegexOptions.IgnoreCase);

        private List<string> errors;

        public FfprobeTool(Setup setup)
            : base(setup.Ffprobe)
        { }

        public MediaInfo GetMediaInfo(string sourcePath)
        {
            errors = new List<string>();
            duration = TimeSpan.Zero;
            var pi = new ProcessStartInfo(ToolPath, string.Format("-i \"{0}\"", sourcePath));
            pi.RedirectStandardOutput = true;
            pi.RedirectStandardError = true;
            pi.UseShellExecute = false;
            pi.CreateNoWindow = true;
            var p = Process.Start(pi);
            Task.Run(() => RunErrorReader(p.StandardError));
            p.PriorityClass = ProcessPriorityClass.BelowNormal;
            p.WaitForExit();
            if (p.ExitCode != 0 || errors.Count > 0)
            {
                throw new ApplicationException("ffprobe.exe ended with errors.");
            }
            return new MediaInfo { Duration = duration };
        }

        private void RunErrorReader(TextReader sr)
        {
            string l;
            while ((l = sr.ReadLine()) != null)
            {
                Debug.WriteLine("FFprobe: " + l);
                ProcessDuration(l);
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

        public class MediaInfo
        {
            public TimeSpan Duration { get; set; }
        }
    }
}
