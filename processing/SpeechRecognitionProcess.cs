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
    class SpeechRecognitionProcess : MultiTaskProcessBase
    {
        private TranscripterTool transcripter;

        private IDictionary<Guid, string> profiles;
        private IDictionary<Guid, Media[]> processGroups;

        public SpeechRecognitionProcess(params IProcess[] dependencies) 
            : base("Text aus Sprache erkennen", dependencies)
        { }

        private void InitializeTool()
        {
            if (transcripter == null)
            {
                transcripter = (TranscripterTool) ToolProvider.Create(typeof (TranscripterTool));
            }
        }

        private string BuildRecognitionResultsFilePath(Media media)
        {
            return Path.Combine(Project.GetWorkingDirectory(), string.Format("{0}.srr", media.Id));
        }

        protected override void Work()
        {
            InitializeTool();

            OnProgress("Verarbeitungsgruppen bilden");

            profiles = transcripter.GetSpeechRecognitionProfiles().ToDictionary(
                t => t.Item1, t => t.Item2);
            processGroups = profiles.Keys
                .Select(pId => Tuple.Create(pId, Project.Media.Where(m => m.RecognitionProfile == pId).ToArray()))
                .Where(t => t.Item2.Length > 0)
                .ToDictionary(t => t.Item1, t => t.Item2);

            OnProgress("Spracherkennung durchführen");
            PhaseCount = processGroups.Count;
            CurrentPhase = 0;
            foreach (var pId in processGroups.Keys)
            {
                var group = processGroups[pId];

                WorkItem = profiles[pId];
                RunTasks(group.Select(m => (ProcessTask)((pH, eH) => RunRecognition(m, pH, eH))).ToArray());
                CurrentPhase = CurrentPhase + 1;
            }
            WorkItem = null;
        }

        private void RunRecognition(Media m, Action<float> progressHandler, Action<string> messageHandler)
        {
            m.ResultsFile = BuildRecognitionResultsFilePath(m);
            if (File.Exists(m.ResultsFile)) return;
            transcripter.RunSpeechRecognition(m.AudioFile, m.ResultsFile, (float)m.Duration, progressHandler);
        }
    }
}