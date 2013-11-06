using System;
using System.Collections.Generic;
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
    abstract class ProcessBase : IProcess
    {
        public string Name { get; private set; }

        private readonly IProcess[] dependencies;

        private Setup setup;
        private ToolProvider toolProvider;
        private Project project;
        private ProcessState state;
        private string workItem;
        private float currentProgress;
        private string errorMessage;

        public event EventHandler Started;

        public event EventHandler<ProcessProgressEventArgs> Progress;
        public event EventHandler<ProcessResultEventArgs> Ended;
        public event PropertyChangedEventHandler PropertyChanged;

        protected ProcessBase(string name, IProcess[] dependencies)
        {
            Name = name;
            this.dependencies = dependencies;

            State = ProcessState.Waiting;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public Setup Setup
        {
            get { return setup; }
            set
            {
                if (State == ProcessState.Running)
                {
                    throw new InvalidOperationException("The application setup can not be changed while the process is running.");
                }
                if (ReferenceEquals(setup, value)) return;
                setup = value;
                OnPropertyChanged();
            }
        }

        public ToolProvider ToolProvider
        {
            get { return toolProvider; }
            set
            {
                if (State == ProcessState.Running)
                {
                    throw new InvalidOperationException("The tool provider can not be changed while the process is running.");
                }
                if (ReferenceEquals(toolProvider, value)) return;
                toolProvider = value;
                OnPropertyChanged();
            }
        }

        public Project Project
        {
            get { return project; }
            set
            {
                if (State == ProcessState.Running)
                {
                    throw new InvalidOperationException("The target project can not be changed while the process is running.");
                }
                if (ReferenceEquals(project, value)) return;
                project = value;
                OnPropertyChanged();
            }
        }

        public ProcessState State
        {
            get { return state; }
            private set
            {
                if (state == value) return;
                state = value;
                OnPropertyChanged();
            }
        }

        public string WorkItem
        {
            get { return workItem; }
            protected set
            {
                if (string.Equals(workItem, value)) return;
                workItem = value;
                OnPropertyChanged();
            }
        }

        public float CurrentProgress
        {
            get { return currentProgress; }
            private set
            {
                if (Math.Abs(value - currentProgress) <= float.Epsilon) return;
                currentProgress = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            private set
            {
                if (string.Equals(errorMessage, value)) return;
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        private void OnStarted()
        {
            var handler = Started;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected void OnProgress(string message)
        {
            OnProgress(CurrentProgress, message);
        }

        protected virtual void OnProgress(float progress, string message)
        {
            CurrentProgress = progress;
            var handler = Progress;
            if (handler != null)
            {
                handler(this, new ProcessProgressEventArgs(progress, message));
            }
        }

        private void OnEnded(bool success, string errMsg = null)
        {
            OnProgress(1f, success ? "Prozess abgeschlossen" : "Prozess fehlgeschlagen");
            ErrorMessage = errMsg;
            State = success ? ProcessState.Finished : ProcessState.Failed;
            var handler = Ended;
            if (handler != null)
            {
                handler(this, new ProcessResultEventArgs(success, errMsg));
            }
        }

        public IEnumerable<IProcess> GetDependencies()
        {
            return dependencies;
        }

        public void Start()
        {
            if (Setup == null) throw new InvalidOperationException("The application setup is not set for the process.");
            if (Project == null) throw new InvalidOperationException("The target project for the process is not set.");
            State = ProcessState.Running;
            OnStarted();
            var t = Task.Run((Action)Work);
            t.ContinueWith(WorkFinalizer);
        }

        private void WorkFinalizer(Task workTask)
        {
            OnEnded(
                !workTask.IsFaulted && !workTask.IsCanceled,
                workTask.Exception != null ? workTask.Exception.Message : null);
        }

        protected float CalculateProgress(int workItemCount, int workItemNo, float itemProgress)
        {
            return (workItemNo + itemProgress) / workItemCount;
        }

        protected abstract void Work();
    }
}
