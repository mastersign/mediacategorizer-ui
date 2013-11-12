using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    class ProfileSelectionProcess : MultiTaskProcessBase
    {
        private TranscripterTool transcripter;

        private IDictionary<Guid, string> profiles;
        private Guid currentProfileId;
        private IDictionary<Media, Dictionary<Guid, TranscripterTool.ConfidenceTestResult>> results;

        public ProfileSelectionProcess(params IProcess[] dependencies)
            : base("Sprachprofilauswahl", dependencies)
        {
            AutoSetWorkItem = false;
        }

        private void InitializeTool()
        {
            transcripter = (TranscripterTool)ToolProvider.Create(typeof(TranscripterTool));
        }

        protected override void Work()
        {
            InitializeTool();

            results = Project.Media.ToDictionary(
                m => m, m => new Dictionary<Guid, TranscripterTool.ConfidenceTestResult>());

            OnProgress("Sprachprofile ermitteln");
            profiles = transcripter.GetSpeechRecognitionProfiles().ToDictionary(t => t.Item1, t => t.Item2);
            var originalProfile = transcripter.GetCurrentSpeechRecognitionProfileId();

            OnProgress("Erkennungssicherheiten ermitteln");
            foreach (var profile in profiles)
            {
                WorkItem = profile.Value;
                RunTestsWithProfile(profile.Key);
            }
            WorkItem = null;
            transcripter.SetCurrentSpeechRecognitionProfile(originalProfile);

            OnProgress("Erkennungssicherheiten auswerten");

            OnProgress("Ergebnisse anzeigen");
            System.Windows.MessageBox.Show(ResultsAsString());
        }

        private void RunTestsWithProfile(Guid profileId)
        {
            currentProfileId = profileId;
            transcripter.SetCurrentSpeechRecognitionProfile(profileId);

            WorkItem = profiles[profileId];

            RunTasks(Project.Media.Select(m => (ProcessTask)((pH, eH) => RunTest(m, pH, eH))).ToArray());
        }

        private void RunTest(Media m, Action<float> progressHandler, Action<string> errorHandler)
        {
            var result = transcripter.RunConfidenceTest(m.AudioFile, Setup.ConfidenceTestDuration);
            lock (results)
            {
                results[m][currentProfileId] = result;
            }
        }

        private string ResultsAsString()
        {
            var sb = new StringBuilder();
            foreach (var m in Project.Media)
            {
                sb.AppendLine(m.Name);
                foreach (var p in profiles)
                {
                    var r = results[m][p.Key];
                    sb.AppendLine("  + " + p.Value + ": ");
                    sb.AppendLine("     - PhrCnt " + r.PhraseCount);
                    sb.AppendLine("     - PhrCnfSum " + r.PhraseConfidenceSum);
                    sb.AppendLine("     - PhrCnfMax " + r.MaxPhraseConfidence);
                    sb.AppendLine("     - PhrCnfMean " + r.MeanPhraseConfidence);
                    sb.AppendLine("     - PhrCnfMin " + r.MinPhraseConfidence);
                    sb.AppendLine("     - WrdCnt " + r.WordCount);
                    sb.AppendLine("     - WrdCnfSum " + r.WordConfidenceSum);
                    sb.AppendLine("     - WrdCnfMax " + r.MaxWordConfidence);
                    sb.AppendLine("     - WrdCnfMean " + r.MeanWordConfidence);
                    sb.AppendLine("     - WrdCnfMin " + r.MinWordConfidence);
                    sb.AppendLine("     - BstPhrCnf " + r.BestPhraseConfidence);
                }
            }
            return sb.ToString();
        }
    }
}
