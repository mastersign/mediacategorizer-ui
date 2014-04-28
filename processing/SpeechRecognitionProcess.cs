using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    class SpeechRecognitionProcess : MultiTaskProcessBase
    {
        private IDictionary<Guid, string> profiles;
        private IDictionary<Guid, Media[]> processGroups;

        public SpeechRecognitionProcess(ProcessChain chain, params IProcess[] dependencies) 
            : base(chain, "Text aus Sprache erkennen", dependencies)
            {
            ProgressWeight = 40;
        }

        private string BuildRecognitionResultsFilePath(Media media)
        {
            return Path.Combine(Project.GetWorkingDirectory(), string.Format("{0}.srr", media.Id));
        }

        private TranscripterTool GetTranscripterTool()
        {
            return (TranscripterTool)ToolProvider.Create(Chain, typeof(TranscripterTool));
        }

        protected override void Work()
        {
            OnProgress("Verarbeitungsgruppen bilden");

            profiles = Project.GetProfilesAsDictionary();

            processGroups = profiles.Keys
                .Select(pId => Tuple.Create(pId, Project.GetMedia().Where(m => m.RecognitionProfile == pId).ToArray()))
                .Where(t => t.Item2.Length > 0)
                .ToDictionary(t => t.Item1, t => t.Item2);

            OnProgress("Spracherkennung durchführen");
            PhaseCount = processGroups.Count;
            CurrentPhase = 0;
            var originalProfile = ProfileManagement.GetCurrentSpeechRecognitionProfileId();
            foreach (var pId in processGroups.Keys)
            {
                var group = processGroups[pId];
                WorkItem = profiles[pId];
                ProfileManagement.SetCurrentSpeechRecognitionProfile(pId);
                RunTasks(group.Select(m => (ProcessTask)((pH, eH) => RunRecognition(m, pH, eH))).ToArray());
                CurrentPhase = CurrentPhase + 1;
            }
            ProfileManagement.SetCurrentSpeechRecognitionProfile(originalProfile);
            WorkItem = null;
        }

        private void RunRecognition(Media m, Action<float> progressHandler, Action<string> errorHandler)
        {
            m.ResultsFile = BuildRecognitionResultsFilePath(m);
            if (File.Exists(m.ResultsFile)) return;
            if (Math.Abs((float) m.Duration) < float.Epsilon)
            {
                Debug.WriteLine("WARNING: Duration of 0 for media " + m.Name);
            }
            var transcripter = GetTranscripterTool(); 
            transcripter.RunSpeechRecognition(m.ExtractedAudioFile, m.ResultsFile, (float)m.Duration, progressHandler);
            if (IsCanceled && File.Exists(m.ResultsFile))
            {
                File.Delete(m.ResultsFile);
            }
        }
    }
}
