using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.fhb.oll.mediacategorizer
{
    class AudioExtractionProcess : IProcessStep
    {
        public string Name { get; set; }

        public string WorkItem { get; set; }

        public event EventHandler<ProgressEventArgs> Progress;

        protected virtual void OnProgress(float progress, string message)
        {
            var handler = Progress;
            if (handler != null) handler(this, new ProgressEventArgs(progress, message));
        }

        public event EventHandler<EndStateEventArgs> Ended;

        protected virtual void OnEnded(bool success, string errorMessage = null)
        {
            var handler = Ended;
            if (handler != null) handler(this, new EndStateEventArgs(success, errorMessage));
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
