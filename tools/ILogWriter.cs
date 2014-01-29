using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.fhb.oll.mediacategorizer.tools
{
    public interface ILogWriter
    {
        void Log(string tool, string line);
    }
}
