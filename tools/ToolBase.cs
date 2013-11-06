using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.tools
{
    abstract class ToolBase
    {
        public string Name { get; protected set; }

        public string ToolPath { get; private set; }

        protected ToolBase(string toolPath)
        {
            ToolPath = toolPath;
            Name = Path.GetFileName(toolPath);
        }

        public virtual bool CheckTool()
        {
            return File.Exists(ToolPath);
        }
    }
}
