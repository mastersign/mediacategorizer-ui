using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.settings;
using Microsoft.Win32;

namespace de.fhb.oll.mediacategorizer.tools
{
    class TranscripterTool : ToolBase
    {
        public TranscripterTool(Setup setup)
            : base(setup.Transcripter)
        { }

        public ConfidenceTestResult RunConfidenceTest(string waveFile, float duration)
        {
            var arguments = string.Format("--confidence-test --test-duration {0} \"{1}\"",
                duration.ToString(CultureInfo.InvariantCulture), waveFile);
            var pi = new ProcessStartInfo(ToolPath, arguments);
            pi.CreateNoWindow = true;
            pi.RedirectStandardOutput = true;
            pi.UseShellExecute = false;
            var p = Process.Start(pi);
            var result =
                new ConfidenceTestResult(p.StandardOutput.ReadToEnd()
                    .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            p.WaitForExit();
            return result;
        }

        public Tuple<Guid, string>[] GetSpeechRecognitionProfiles()
        {
            var tokensKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Speech\RecoProfiles\Tokens");
            if (tokensKey == null) throw new ApplicationException("Could not find any speech recognition profiles.");
            var tokens = tokensKey.GetSubKeyNames();
            return tokens
                .Select(tn => Tuple.Create(
                    Guid.Parse(tn),
                    tokensKey.OpenSubKey(tn).GetValue(string.Empty) as string))
                .ToArray();
        }

        public Guid GetCurrentSpeechRecognitionProfileId()
        {
            var recoProfilesKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Speech\RecoProfiles");
            if (recoProfilesKey == null) throw new ApplicationException("Could not find a default speech recognition profile.");
            var path = recoProfilesKey.GetValue("DefaultTokenId") as string;
            var guid = path.Substring(path.LastIndexOf('\\') + 1);
            return Guid.Parse(guid);
        }

        public void SetCurrentSpeechRecognitionProfile(Guid id)
        {
            var recoProfilesKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Speech\RecoProfiles", true);
            if (recoProfilesKey == null) throw new ApplicationException("Could not find a default speech recognition profile.");
            var path = string.Format(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Speech\RecoProfiles\Tokens\{0:B}", id);
            recoProfilesKey.SetValue("DefaultTokenId", path);
            recoProfilesKey.Flush();
        }

        public class ConfidenceTestResult
        {
            private readonly IDictionary<string, string> values;

            public ConfidenceTestResult(IEnumerable<string> transcripterOutput)
            {
                values = transcripterOutput.ToDictionary(
                    l => l.Trim().Split('=')[0],
                    l => l.Trim().Split('=')[1]);
            }

            private float GetFloatValue(string name)
            {
                return float.Parse(values[name], NumberStyles.Float, CultureInfo.InvariantCulture);
            }

            private int GetIntValue(string name)
            {
                return int.Parse(values[name], NumberStyles.Float, CultureInfo.InvariantCulture);
            }

            public int PhraseCount { get { return GetIntValue("PhraseCount"); } }
            public float PhraseConfidenceSum { get { return GetFloatValue("PhraseConfidenceSum"); } }
            public float MaxPhraseConfidence { get { return GetFloatValue("MaxPhraseConfidence"); } }
            public float MeanPhraseConfidence { get { return GetFloatValue("MeanPhraseConfidence"); } }
            public float MinPhraseConfidence { get { return GetFloatValue("MinPhraseConfidence"); } }
            public int WordCount { get { return GetIntValue("WordCount"); } }
            public float WordConfidenceSum { get { return GetFloatValue("WordConfidenceSum"); } }
            public float MaxWordConfidence { get { return GetFloatValue("MaxWordConfidence"); } }
            public float MeanWordConfidence { get { return GetFloatValue("MeanWordConfidence"); } }
            public float MinWordConfidence { get { return GetFloatValue("MinWordConfidence"); } }
            public float BestPhraseConfidence { get { return GetFloatValue("BestPhraseConfidence"); } }
        }
    }
}
