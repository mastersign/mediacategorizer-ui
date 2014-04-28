using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer
{
    public interface ILogWriter
    {
        void Log(string tool, string line);
    }
}
