using System;
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
    public class ProcessChain : DispatcherObject, ILogWriter, INotifyPropertyChanged
    {
        private IProcess[] processes;

        public ObservableCollection<IProcess> WaitingProcesses { get; private set; }

        public ObservableCollection<IProcess> RunningProcesses { get; private set; }

        public ObservableCollection<IProcess> EndedProcesses { get; private set; }

        public event EventHandler ChainStarted;

        private DateTime? startTime;

        public event EventHandler ChainEnded;

        private DateTime? endTime;

        private bool isRunning;

        private bool isFailed;

        private bool isEnded;

        private float totalProgressWeight;

        private float progress;

        private readonly object lockObject = new object();

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly List<Tuple<string, string>> preInitializedLogBuffer = new List<Tuple<string, string>>();

        private LogWriter logWriter;

        private bool changedStateOfProject;

        public ProcessChain(Setup setup, ToolProvider toolProvider, Project project)
        {
            VerifyAccess();

            Setup = setup;
            ToolProvider = toolProvider;
            Project = project;

            WaitingProcesses = new ObservableCollection<IProcess>();
            RunningProcesses = new ObservableCollection<IProcess>();
            EndedProcesses = new ObservableCollection<IProcess>();

            Initialize();
        }

        private void Initialize()
        {
            VerifyAccess();

            DisposeLogWriter();
            preInitializedLogBuffer.Clear();

            StartTime = null;
            EndTime = null;

            Progress = 0f;
            totalProgressWeight = 0f;
            IsFailed = false;
            IsRunning = false;
            IsEnded = false;

            processes = CreateProcessChain();
            //processes = CreateDummyProcessChain();
            //processes = CreateFailingDummyProcessChain();

            WaitingProcesses.Clear();
            RunningProcesses.Clear();
            EndedProcesses.Clear();
            foreach (var p in processes)
            {
                p.Dispatcher = Dispatcher;
                p.Started += ProcessStartedHandler;
                p.Ended += ProcessEndedHandler;
                p.Progress += ProcessProgressHandler;
                totalProgressWeight += p.ProgressWeight;
                WaitingProcesses.Add(p);
            }
        }

        private IProcess[] CreateProcessChain()
        {
            var projectPreparation = new PrepareProjectProcess(this);
            var mediaInspectionProcess = new MediaInspectionProcess(this, projectPreparation);
            var audioExtraction = new AudioExtractionProcess(this, projectPreparation);
            var waveformVisualization = new WaveformProcess(this, projectPreparation, audioExtraction);
            var profileSelection = new ProfileSelectionProcess(this, projectPreparation, mediaInspectionProcess, audioExtraction);
            var speechRecognitionProcess = new SpeechRecognitionProcess(this, projectPreparation, mediaInspectionProcess, audioExtraction, profileSelection);
            var analyzeAndOutput = new AnalyzeResultsAndWriteOutputProcess(this, projectPreparation, waveformVisualization, speechRecognitionProcess);
            var projectFinalization = new FinalizeProjectProcess(this, analyzeAndOutput);

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

        private IProcess[] CreateDummyProcessChain()
        {
            var p1 = new DummyProcess(this, "Dummy 1");
            var p2 = new DummyProcess(this, "Dummy 2");
            var p2a = new DummyProcess(this, "Dummy 2a", p2);
            var p2b = new DummyProcess(this, "Dummy 2b", p2);
            var p3 = new DummyProcess(this, "Dummy 3", p1, p2b);

            return new IProcess[] { p1, p2, p2a, p2b, p3 };
        }

        private IProcess[] CreateFailingDummyProcessChain()
        {
            var p1 = new DummyProcess(this, "Dummy 1");
            var p2 = new DummyProcess(this, "Dummy 2");
            var p2a = new DummyProcess(this, "Dummy 2a", p2);
            var p2b = new DummyProcess(this, "Dummy 2b", p2) { Failing = true };
            var p3 = new DummyProcess(this, "Dummy 3", p1, p2b);

            return new IProcess[] { p1, p2, p2a, p2b, p3 };
        }

        public Setup Setup { get; private set; }

        public ToolProvider ToolProvider { get; private set; }

        public Project Project { get; private set; }

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
            StartTime = DateTime.Now;
            Log("Process Chain", "Started");
            PostSynced(ChainStarted, this, EventArgs.Empty);
        }

        public DateTime? StartTime
        {
            get { return startTime; }
            private set
            {
                if (startTime == value) return;
                startTime = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnChainEnded()
        {
            EndTime = DateTime.Now;
            if (changedStateOfProject == false) Project.AcceptChanges();
            Log("Process Chain", "Ended");
            PostSynced(ChainEnded, this, EventArgs.Empty);
        }

        public DateTime? EndTime
        {
            get { return endTime; }
            private set
            {
                if (endTime == value) return;
                endTime = value;
                OnPropertyChanged();
            }
        }

        private void ProcessStartedHandler(object sender, EventArgs eventArgs)
        {
            lock (lockObject)
            {
                WaitingProcesses.Remove((IProcess)sender);
                RunningProcesses.Add((IProcess)sender);
                IsRunning = ComputeIsRunning();
            }
        }

        private void ProcessEndedHandler(object sender, ProcessResultEventArgs e)
        {
            lock (lockObject)
            {
                RunningProcesses.Remove((IProcess)sender);
                EndedProcesses.Add((IProcess)sender);
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
                DisposeLogWriter();
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
            changedStateOfProject = Project.IsChanged;
            GoAhead();
        }

        public void InitializeLogWriter(LogWriter w)
        {
            if (logWriter != null)
            {
                throw new InvalidOperationException("The LogWriter is allready initialized.");
            }
            logWriter = w;
            foreach (var logEntry in preInitializedLogBuffer)
            {
                logWriter.Log(logEntry.Item1, logEntry.Item2);
            }
            preInitializedLogBuffer.Clear();
        }

        public void Log(string tool, string line)
        {
            if (logWriter == null)
            {
                Debug.WriteLine("PRE-INIT: {0}: {1}", tool, line);
                preInitializedLogBuffer.Add(Tuple.Create(tool, line));
            }
            else
            {
                logWriter.Log(tool, line);
            }
        }

        public void DisposeLogWriter()
        {
            if (logWriter == null) return;
            logWriter.Dispose();
            logWriter = null;
        }
    }
}
