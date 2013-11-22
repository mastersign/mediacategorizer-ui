﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Threading;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.settings;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    public class ProcessChain : DispatcherObject, INotifyPropertyChanged
    {
        private IProcess[] processes;

        public ObservableCollection<IProcess> WaitingProcesses { get; private set; }

        public ObservableCollection<IProcess> RunningProcesses { get; private set; }

        public ObservableCollection<IProcess> EndedProcesses { get; private set; }

        public event EventHandler ChainStarted;

        public event EventHandler ChainEnded;

        private bool isRunning;

        private bool isFailed;

        private bool isEnded;

        private float totalProgressWeight;

        private float progress;

        private readonly object lockObject = new object();

        public event PropertyChangedEventHandler PropertyChanged;

        public Setup Setup { get; private set; }

        public ToolProvider ToolProvider { get; private set; }

        public Project Project { get; private set; }

        public ProcessChain(Setup setup, ToolProvider toolProvider, Project project)
        {
            VerifyAccess();

            Setup = setup;
            ToolProvider = toolProvider;
            Project = project;

            Initialize();
        }

        private void Initialize()
        {
            VerifyAccess();

            Progress = 0f;
            totalProgressWeight = 0f;
            IsFailed = false;
            IsRunning = false;
            IsEnded = false;
            
            processes = CreateProcessChain();
            //processes = CreateDummyProcessChain();

            foreach (var p in processes)
            {
                p.Setup = Setup;
                p.ToolProvider = ToolProvider;
                p.Project = Project;
                p.Dispatcher = Dispatcher;
                p.Started += ProcessStartedHandler;
                p.Ended += ProcessEndedHandler;
                p.Progress += ProcessProgressHandler;
                totalProgressWeight += p.ProgressWeight;
            }

            WaitingProcesses = new ObservableCollection<IProcess>(processes);
            RunningProcesses = new ObservableCollection<IProcess>();
            EndedProcesses = new ObservableCollection<IProcess>();
        }

        private static IProcess[] CreateProcessChain()
        {
            var projectPreparation = new PrepareProjectProcess();
            var mediaInspectionProcess = new MediaInspectionProcess(projectPreparation);
            var audioExtraction = new AudioExtractionProcess(projectPreparation);
            var waveformVisualization = new WaveformProcess(projectPreparation, audioExtraction);
            var profileSelection = new ProfileSelectionProcess(projectPreparation, mediaInspectionProcess, audioExtraction);
            var speechRecognitionProcess = new SpeechRecognitionProcess(projectPreparation, mediaInspectionProcess, audioExtraction, profileSelection);
            var analyzeAndOutput = new AnalyzeResultsAndWriteOutputProcess(projectPreparation, waveformVisualization, speechRecognitionProcess);
            var projectFinalization = new FinalizeProjectProcess(analyzeAndOutput);

            return new IProcess[]
            {
                projectPreparation, 
                mediaInspectionProcess,
                audioExtraction, 
                waveformVisualization,
                profileSelection,
                speechRecognitionProcess,
                analyzeAndOutput,
                projectFinalization
            };
        }

        private static IProcess[] CreateDummyProcessChain()
        {
            var p1 = new DummyProcess("Dummy 1");
            var p2 = new DummyProcess("Dummy 2");
            var p2a = new DummyProcess("Dummy 2a", p2);
            var p2b = new DummyProcess("Dummy 2b", p2);
            var p3 = new DummyProcess("Dummy 3", p1, p2b);

            return new IProcess[] { p1, p2, p2a, p2b, p3 };
        }

        protected void PostSynced(Delegate d, params object[] args)
        {
            if (d == null) return;
            if (Dispatcher == null)
            {
                d.DynamicInvoke(args);
            }
            else
            {
                Dispatcher.InvokeAsync(() => d.DynamicInvoke(args));
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PostSynced(PropertyChanged, this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnChainStarted()
        {
            PostSynced(ChainStarted, this, EventArgs.Empty);
        }

        protected virtual void OnChainEnded()
        {
            PostSynced(ChainEnded, this, EventArgs.Empty);
        }

        private void ProcessStartedHandler(object sender, EventArgs eventArgs)
        {
            lock (lockObject)
            {
                WaitingProcesses.Remove((IProcess) sender);
                RunningProcesses.Add((IProcess) sender);
                IsRunning = ComputeIsRunning();
            }
        }

        private void ProcessEndedHandler(object sender, ProcessResultEventArgs e)
        {
            lock (lockObject)
            {
                RunningProcesses.Remove((IProcess) sender);
                EndedProcesses.Add((IProcess) sender);
                IsFailed = ComputeIsFailed();
                IsRunning = ComputeIsRunning();
                IsEnded = !IsRunning;
                GoAhead();
            }
        }

        private void ProcessProgressHandler(object sender, ProcessProgressEventArgs e)
        {
            Progress = processes.Sum(p => p.CurrentProgress * p.ProgressWeight) / totalProgressWeight;
        }

        private bool ComputeIsRunning()
        {
            return processes.Any(p => p.State == ProcessState.Running) ||
                (CollectWaitingProcesses().Any() && !processes.Any(p => p.State == ProcessState.Failed));
        }

        public bool IsRunning
        {
            get { return isRunning; }
            set
            {
                if (isRunning == value) return;
                isRunning = value;
                OnPropertyChanged();
                if (isRunning) OnChainStarted();
            }
        }

        private bool ComputeIsFailed()
        {
            return processes.Any(p => p.State == ProcessState.Failed);
        }

        public bool IsFailed
        {
            get { return isFailed; }
            private set
            {
                if (isFailed == value) return;
                isFailed = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnded
        {
            get { return isEnded; }
            private set
            {
                if (isEnded == value) return;
                isEnded = value;
                OnPropertyChanged();
                if (isEnded) OnChainEnded();
            }
        }

        public float Progress
        {
            get { return progress; }
            private set
            {
                if (Math.Abs(progress - value) <= float.Epsilon) return;
                progress = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<IProcess> CollectWaitingProcesses()
        {
            return from p in processes
                   where p.State == ProcessState.Waiting
                      && p.GetDependencies().All(dp => dp.State == ProcessState.Finished)
                   select p;
        }

        private void GoAhead()
        {
            var waitingProcesses = CollectWaitingProcesses().ToArray();
            foreach (var p in waitingProcesses)
            {
                p.Start();
            }
        }

        public void Reset()
        {
            foreach (var p in processes)
            {
                p.Started -= ProcessStartedHandler;
                p.Ended -= ProcessEndedHandler;
                p.Progress -= ProcessProgressHandler;
            }
            Initialize();
        }

        public void Start()
        {
            if (IsRunning)
            {
                throw new InvalidOperationException("A running chain can not be started.");
            }
            if (IsEnded)
            {
                throw new InvalidOperationException("An ended chain can not be started. Use the Reset method before restart the chain.");
            }
            GoAhead();
        }
    }
}
