using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.fhb.oll.mediacategorizer.processing
{
    class ProcessProgressEventArgs : EventArgs
    {
        public float Progress { get; private set; }

        public string Message { get; private set; }

        public ProcessProgressEventArgs(float progress, string message)
        {
            Progress = progress;
            Message = message;
        }
    }
}
