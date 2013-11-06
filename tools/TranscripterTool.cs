using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.settings;

namespace de.fhb.oll.mediacategorizer.tools
{
    class TranscripterTool : ToolBase
    {
        public TranscripterTool(Setup setup)
            : base(setup.Transcripter)
        {
        }
    }
}
