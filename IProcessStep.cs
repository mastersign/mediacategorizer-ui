using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer
{
    interface IProcessStep
    {
        string Name { get; }

        string WorkItem { get; }

        event EventHandler<ProgressEventArgs> Progress;

        event EventHandler<EndStateEventArgs> Ended;

        void Start();
    }
}
