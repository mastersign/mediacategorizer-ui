using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace de.fhb.oll.mediacategorizer.processing
{
    public interface IProcess : INotifyPropertyChanged
    {
        string Name { get; }

        Dispatcher Dispatcher { get; set; }

        string WorkItem { get; }
        
        ProcessState State { get; }
        
        float ProgressWeight { get; }
        
        float CurrentProgress { get; }

        string ProgressMessage { get; }
        
        string ErrorMessage { get; }

        string CurrentMessage { get; }

        string DetailedErrorMessage { get; }

        event EventHandler Started;

        event EventHandler<ProcessProgressEventArgs> Progress;

        event EventHandler<ProcessResultEventArgs> Ended;

        IEnumerable<IProcess> GetDependencies();

        void Start();

        void Cancel();
    }
}
