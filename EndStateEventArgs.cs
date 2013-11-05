using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer
{
    class EndStateEventArgs : EventArgs
    {
        public bool Success { get; private set; }

        public string ErrorMessage { get; private set; }

        public EndStateEventArgs(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}
