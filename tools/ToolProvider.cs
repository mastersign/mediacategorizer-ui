using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using de.fhb.oll.mediacategorizer.settings;

namespace de.fhb.oll.mediacategorizer.tools
{
    public class ToolProvider
    {
        private readonly Setup applicationSetup;

        public ToolProvider(Setup applicationSetup)
        {
            this.applicationSetup = applicationSetup;
            ToolTypes = new[]
            {
                typeof (FfmpegTool),
                typeof (FfprobeTool),
                typeof (WaveVizTool),
                typeof (TranscripterTool),
                typeof (DistilleryTool),
            };
        }

        public Type[] ToolTypes { get; private set; }

        public object Create(ILogWriter logWriter, Type t)
        {
            if (!ToolTypes.Contains(t)) throw new NotSupportedException();
            return Activator.CreateInstance(t, logWriter, applicationSetup);
        }
    }
}
