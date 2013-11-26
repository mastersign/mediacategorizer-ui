using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.settings;

namespace de.fhb.oll.mediacategorizer.processing
{
    internal delegate void ProcessTask(Action<float> progressHandler, Action<string> errorHandler);

    internal abstract class MultiTaskProcessBase : ProcessBase
    {
        protected MultiTaskProcessBase(ProcessChain chain, string name, IProcess[] dependencies)
            : base(chain, name, dependencies)
        {
            PhaseCount = 1;
            CurrentPhase = 0;
            CancelOnError = true;
        }

        private float[] progressList;
        private Queue<Tuple<ProcessTask, int>> taskList;
        private HashSet<int> runningTasks;

        private int maxParallelTasks;

        protected int PhaseCount { get; set; }

        protected int CurrentPhase { get; set; }

        protected bool AutoSetWorkItem { get; set; }

        protected bool CancelOnError { get; set; }

        private ConcurrentBag<string> errors;

        private readonly ManualResetEvent finishedEvent = new ManualResetEvent(false);

        private void SetMaxParallelTasks()
        {
            switch (Setup.Parallelization)
            {
                case ParallelizationMode.None:
                    maxParallelTasks = 1;
                    break;
                case ParallelizationMode.Auto:
                    maxParallelTasks = Environment.ProcessorCount;
                    break;
                case ParallelizationMode.Manual:
                    maxParallelTasks = Setup.ParallelTasks;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected void RunTasks(params ProcessTask[] tasks)
        {
            if (Dispatcher.CheckAccess())
            {
                throw new InvalidOperationException("The method RunTasks need to be called on another than the dispatcher thread.");
            }
            SetMaxParallelTasks();

            progressList = new float[tasks.Length];
            taskList = new Queue<Tuple<ProcessTask, int>>(tasks.Select((t, i) => Tuple.Create(t, i)));
            runningTasks = new HashSet<int>();
            errors = new ConcurrentBag<string>();

            finishedEvent.Reset();
            Task.Run((Action)WorkQueue);
            finishedEvent.WaitOne();
            if (errors.Count > 0)
            {
                OnError(string.Join(Environment.NewLine, errors));
            }
        }

        private void WorkQueue()
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.InvokeAsync(WorkQueue);
                return;
            }

            if (taskList.Count == 0 || CancelOnError && errors.Count > 0)
            {
                if (runningTasks.Count == 0)
                {
                    finishedEvent.Set();
                }
                return;
            }

            var newTaskCount = Math.Min(taskList.Count, maxParallelTasks - runningTasks.Count);
            for (var i = 0; i < newTaskCount; i++)
            {
                ProcessTask(taskList.Dequeue());
            }
        }

        private void ProcessTask(Tuple<ProcessTask, int> t)
        {
            var task = t.Item1;
            var id = t.Item2;
            runningTasks.Add(id);
            Debug.WriteLine("Process '{0}' in phase {1} started task {2} ", Name, CurrentPhase + 1, id + 1);
            UpdateWorkItem();
            Task.Run(() =>
            {
                try
                {
                    task(p => ProgressHandler(id, p), ErrorHandler);
                }
                catch (Exception exc)
                {
                    ErrorHandler(exc.Message);
                }
                TaskFinished(id);
            });
        }

        private void TaskFinished(int id)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.InvokeAsync(() => TaskFinished(id));
                return;
            }

            Debug.WriteLine("Process '{0}' in phase {1} finished task {2} ", Name, CurrentPhase + 1, id + 1);
            runningTasks.Remove(id);
            UpdateWorkItem();
            WorkQueue();
        }

        private void UpdateWorkItem()
        {
            if (!AutoSetWorkItem) return;
            WorkItem = string.Join(", ", runningTasks.Select(t => ++t));
        }

        private void ProgressHandler(int task, float value)
        {
            progressList[task] = value;
            OnProgress((CurrentPhase + progressList.Sum() / progressList.Length) / PhaseCount);
        }

        private void ErrorHandler(string message)
        {
            errors.Add(message);
        }
    }
}
