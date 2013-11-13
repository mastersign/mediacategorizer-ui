﻿using System;
using System.Collections.Generic;
using System.IO;
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
            : base("Sprachprofile auswählen", dependencies)
        {
            AutoSetWorkItem = false;
        }

        private void InitializeTool()
        {
            if (transcripter == null)
            {
                transcripter = (TranscripterTool) ToolProvider.Create(typeof (TranscripterTool));
            }
        }

        private string BuildProfileSelectionFilePath(Media media, Guid profileId)
        {
            return Path.Combine(Project.GetWorkingDirectory(), string.Format("{0:D}_{1}.ctr", profileId, media.Id));
        }

        protected override void Work()
        {
            InitializeTool();

            OnProgress("Sprachprofile ermitteln");
            profiles = transcripter.GetSpeechRecognitionProfiles().ToDictionary(t => t.Item1, t => t.Item2);

            OnProgress("Erkennungssicherheiten ermitteln");
            RunTestsForAllProfiles();

            OnProgress("Erkennungssicherheiten auswerten");
            var criterion = GetCriterion();
            foreach (var m in Project.Media)
            {
                WorkItem = m.Name;
                m.RecognitionProfile = results[m].OrderBy(kvp => -criterion(kvp.Value)).First().Key;
            }
            WorkItem = null;
        }

        private Func<TranscripterTool.ConfidenceTestResult, float> GetCriterion()
        {
            switch (Project.Configuration.ProfileSelectionCriterion)
            {
                case ProfileSelectionCriterion.PhraseCount:
                    return tr => tr.PhraseCount;
                case ProfileSelectionCriterion.PhraseConfidenceSum:
                    return tr => tr.PhraseConfidenceSum;
                case ProfileSelectionCriterion.MaxPhraseConfidence:
                    return tr => tr.MaxPhraseConfidence;
                case ProfileSelectionCriterion.MeanPhraseConfidence:
                    return tr => tr.MeanPhraseConfidence;
                case ProfileSelectionCriterion.MinPhraseConfidence:
                    return tr => tr.MinPhraseConfidence;
                case ProfileSelectionCriterion.WordCount:
                    return tr => tr.WordCount;
                case ProfileSelectionCriterion.WordConfidenceSum:
                    return tr => tr.WordConfidenceSum;
                case ProfileSelectionCriterion.MaxWordConfidence:
                    return tr => tr.MaxWordConfidence;
                case ProfileSelectionCriterion.MeanWordConfidence:
                    return tr => tr.MeanWordConfidence;
                case ProfileSelectionCriterion.BestWordConfidence:
                    return tr => tr.BestWordConfidence;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RunTestsForAllProfiles()
        {
            results = Project.Media.ToDictionary(
                m => m, m => new Dictionary<Guid, TranscripterTool.ConfidenceTestResult>());
            PhaseCount = profiles.Count;
            CurrentPhase = 0;

            var originalProfile = transcripter.GetCurrentSpeechRecognitionProfileId();
            foreach (var profile in profiles)
            {
                WorkItem = profile.Value;
                RunTestsForProfile(profile.Key);
                CurrentPhase = CurrentPhase + 1;
            }
            transcripter.SetCurrentSpeechRecognitionProfile(originalProfile);
            WorkItem = null;
        }

        private void RunTestsForProfile(Guid profileId)
        {
            currentProfileId = profileId;
            transcripter.SetCurrentSpeechRecognitionProfile(profileId);

            WorkItem = profiles[profileId];

            RunTasks(Project.Media.Select(m => (ProcessTask)((pH, eH) => RunTest(m, pH, eH))).ToArray());
        }

        private void RunTest(Media m, Action<float> progressHandler, Action<string> errorHandler)
        {
            var file = BuildProfileSelectionFilePath(m, currentProfileId);
            if (!File.Exists(file))
            {
                var result = transcripter.RunConfidenceTest(m.AudioFile, Setup.ConfidenceTestDuration, progressHandler);
                using (var w = new StreamWriter(file, false, Encoding.UTF8))
                {
                    result.Write(w);
                }
            }
            using (var r = new StreamReader(file, Encoding.UTF8))
            {
                var result = new TranscripterTool.ConfidenceTestResult(r);
                lock (results)
                {
                    results[m][currentProfileId] = result;
                }
            }
        }
    }
}
