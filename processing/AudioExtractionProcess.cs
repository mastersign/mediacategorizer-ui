using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.fhb.oll.mediacategorizer.processing
{
    class AudioExtractionProcess : ProcessBase
    {
        public AudioExtractionProcess(params IProcess[] dependencies) 
            : base("Extraktion der Audiospur", dependencies)
        { }

        protected override void Work()
        {
            throw new NotImplementedException();
        }
    }
}
