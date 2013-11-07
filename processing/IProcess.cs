using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.settings;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    public interface IProcess : INotifyPropertyChanged
    {
        string Name { get; }

        Setup Setup { get; set; }
        
        ToolProvider ToolProvider { get; set; }
        
        Project Project { get; set; }
        
        string WorkItem { get; }
        
        ProcessState State { get; }
        
        float CurrentProgress { get; }
        
        string ErrorMessage { get; }

        event EventHandler Started;

        event EventHandler<ProcessProgressEventArgs> Progress;

        event EventHandler<ProcessResultEventArgs> Ended;

        IEnumerable<IProcess> GetDependencies();

        void Start();
    }
}
