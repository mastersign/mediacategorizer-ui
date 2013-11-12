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
        private readonly IProcess[] processes;

        public ObservableCollection<IProcess> WaitingProcesses { get; private set; }

        public ObservableCollection<IProcess> RunningProcesses { get; private set; }

        public ObservableCollection<IProcess> EndedProcesses { get; private set; }

        public event EventHandler ChainStarted;

        public event EventHandler ChainEnded;

        private bool isRunning;

        private bool isFailed;

        private float progress;

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
            }

            WaitingProcesses = new ObservableCollection<IProcess>(processes);
            RunningProcesses = new ObservableCollection<IProcess>();
            EndedProcesses = new ObservableCollection<IProcess>();
        }

        private static IProcess[] CreateProcessChain()
        {
            var projectPreparation = new PrepareProjectProcess();
            var audioExtraction = new AudioExtractionProcess(projectPreparation);
            var waveformVisualization = new WaveformProcess(projectPreparation, audioExtraction);
            var projectFinalization = new FinalizeProjectProcess(projectPreparation, audioExtraction, waveformVisualization);

            return new IProcess[]
            {
                projectPreparation, 
                audioExtraction, 
                waveformVisualization,
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

        private void ProcessStartedHandler(object sender, EventArgs eventArgs)
        {
            WaitingProcesses.Remove((IProcess)sender);
            RunningProcesses.Add((IProcess)sender);
            IsRunning = ComputeIsRunning();
        }

        private void ProcessEndedHandler(object sender, ProcessResultEventArgs e)
        {
            RunningProcesses.Remove((IProcess)sender);
            EndedProcesses.Add((IProcess)sender);
            IsRunning = ComputeIsRunning();
            IsFailed = ComputeIsFailed();
            Start();
        }

        private void ProcessProgressHandler(object sender, ProcessProgressEventArgs e)
        {
            Progress = processes.Sum(p => p.CurrentProgress) / processes.Length;
        }

        private bool ComputeIsRunning()
        {
            return processes.Any(p => p.State == ProcessState.Running);
        }

        public bool IsRunning
        {
            get { return isRunning; }
            set
            {
                if (isRunning == value) return;
                isRunning = value;
                OnPropertyChanged();
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

        public void Start()
        {
            var waitingProcesses = CollectWaitingProcesses().ToArray();
            foreach (var p in waitingProcesses)
            {
                p.Start();
            }
        }
    }
}
