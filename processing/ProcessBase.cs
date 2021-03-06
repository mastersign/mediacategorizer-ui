﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.settings;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    abstract class ProcessBase : IProcess
    {
        protected ProcessChain Chain { get; private set; }

        public string Name { get; private set; }

        private readonly IProcess[] dependencies;

        private ProcessState state;
        private string workItem;
        private float currentProgress;
        private string progressMessage;
        private string errorMessage;
        private string detailedErrorMessage;

        public event EventHandler Started;

        public event EventHandler<ProcessProgressEventArgs> Progress;
        public event EventHandler<ProcessResultEventArgs> Ended;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsCanceled { get; private set; }

        public Dispatcher Dispatcher { get; set; }

        protected ProcessBase(ProcessChain chain, string name, IProcess[] dependencies)
        {
            Chain = chain;
            Name = name;
            this.dependencies = dependencies;

            ProgressWeight = 1f;
            State = ProcessState.Waiting;
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

        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PostSynced(PropertyChanged, this, new PropertyChangedEventArgs(name));
        }

        protected Project Project { get { return Chain.Project; } }

        protected Setup Setup { get { return Chain.Setup; } }

        protected ToolProvider ToolProvider { get { return Chain.ToolProvider; } }

        public ProcessState State
        {
            get { return state; }
            private set
            {
                if (state == value) return;
                state = value;
                Log("State = " + state);
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
                Log("WorkItem = " + workItem);
                OnPropertyChanged();
            }
        }

        public float ProgressWeight { get; protected set; }

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

        public string ProgressMessage
        {
            get { return progressMessage; }
            private set
            {
                if (string.Equals(progressMessage, value)) return;
                progressMessage = value;
                OnPropertyChanged();
                OnPropertyChanged("CurrentMessage");
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
                OnPropertyChanged("CurrentMessage");
            }
        }

        public string DetailedErrorMessage
        {
            get { return detailedErrorMessage; }
            private set
            {
                if (string.Equals(detailedErrorMessage, value)) return;
                detailedErrorMessage = value;
                OnPropertyChanged();
            }
        }

        public string CurrentMessage
        {
            get { return ErrorMessage ?? ProgressMessage; }
        }

        private void OnStarted()
        {
            PostSynced(Started, this, EventArgs.Empty);
        }

        protected void OnProgress(float progress)
        {
            OnProgress(progress, ProgressMessage);
        }

        protected void OnProgress(string message)
        {
            OnProgress(CurrentProgress, message);
        }

        protected virtual void OnProgress(float progress, string message)
        {
            CurrentProgress = progress;
            ProgressMessage = message;
            PostSynced(Progress, this, new ProcessProgressEventArgs(progress, message));
        }

        protected void OnError(string message)
        {
            DetailedErrorMessage = DetailedErrorMessage + message + Environment.NewLine;
            ErrorMessage = message;
        }

        private void OnEnded(bool success, string errMsg = null)
        {
            if (success)
            {
                WorkItem = null;
                OnProgress(1, "abgeschlossen");
            }
            ErrorMessage = errMsg;
            State = success ? ProcessState.Finished : ProcessState.Failed;
            PostSynced(Ended, this, new ProcessResultEventArgs(success, errMsg));
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

        public void Cancel()
        {
            if (State != ProcessState.Running) return;
            IsCanceled = true;
        }

        private void WorkFinalizer(Task workTask)
        {
            if (workTask.Exception != null)
            {
                DetailedErrorMessage = DetailedErrorMessage + workTask.Exception + Environment.NewLine;
            }
            OnEnded(
                ErrorMessage == null && !workTask.IsFaulted && !workTask.IsCanceled,
                ErrorMessage ?? (workTask.Exception != null ? workTask.Exception.Message : null));
        }

        protected float CalculateProgress(int workItemCount, int workItemNo, float itemProgress)
        {
            return (workItemNo + itemProgress) / workItemCount;
        }

        protected void Log(string line)
        {
            Chain.Log(Name, line);
        }

        protected abstract void Work();

        public override string ToString()
        {
            return string.Format("Prozess {0}: {1:P1} ({2})", Name, CurrentProgress, State);
        }

        public string SimpleStringRepresentation { get { return ToString(); } }
    }
}
