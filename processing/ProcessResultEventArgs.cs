using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.fhb.oll.mediacategorizer.processing
{
    public class ProcessResultEventArgs : EventArgs
    {
        public bool Success { get; private set; }

        public string ErrorMessage { get; private set; }

        public ProcessResultEventArgs(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}
