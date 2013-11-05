using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer
{
    class ProgressEventArgs : EventArgs
    {
        public float Progress { get; private set; }

        public string Message { get; private set; }

        public ProgressEventArgs(float progress, string message)
        {
            Progress = progress;
            Message = message;
        }
    }
}
