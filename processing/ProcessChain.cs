using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.settings;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    class ProcessChain : INotifyPropertyChanged
    {
        private readonly IProcess[] processes;

        public ObservableCollection<IProcess> WaitingProcesses { get; private set; }

        public ObservableCollection<IProcess> RunningProcesses { get; private set; }

        public ObservableCollection<IProcess> EndedProcesses { get; private set; }

        private bool isRunning;

        private bool isFailed;

        public event PropertyChangedEventHandler PropertyChanged;

        public ProcessChain(Setup setup, ToolProvider toolProvider, Project project)
        {
            var prepareProject = new PrepareProjectProcess();
            var audioExtraction = new AudioExtractionProcess(prepareProject);
            var finalizeProject = new FinalizeProjectProcess(audioExtraction);

            processes = new IProcess[]
            {
                prepareProject, 
                audioExtraction, 
                finalizeProject
            };

            foreach (var p in processes)
            {
                p.Setup = setup;
                p.ToolProvider = toolProvider;
                p.Project = project;
                p.Started += ProcessStartedHandler;
                p.Ended += ProcessEndedHandler;
            }

            WaitingProcesses = new ObservableCollection<IProcess>(CollectWaitingProcesses());
            RunningProcesses = new ObservableCollection<IProcess>();
            EndedProcesses = new ObservableCollection<IProcess>();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
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

        public IEnumerable<IProcess> CollectWaitingProcesses()
        {
            return from p in processes
                   where p.GetDependencies().All(dp => dp.State == ProcessState.Finished)
                   select p;
        }
    }
}
