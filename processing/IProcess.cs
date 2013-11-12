using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.settings;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    public interface IProcess : INotifyPropertyChanged
    {
        string Name { get; }

        Dispatcher Dispatcher { get; set; }

        Setup Setup { get; set; }
        
        ToolProvider ToolProvider { get; set; }
        
        Project Project { get; set; }
        
        string WorkItem { get; }
        
        ProcessState State { get; }
        
        float CurrentProgress { get; }

        string ProgressMessage { get; }
        
        string ErrorMessage { get; }

        string CurrentMessage { get; }

        event EventHandler Started;

        event EventHandler<ProcessProgressEventArgs> Progress;

        event EventHandler<ProcessResultEventArgs> Ended;

        IEnumerable<IProcess> GetDependencies();

        void Start();
    }
}
