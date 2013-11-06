﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using de.fhb.oll.mediacategorizer.settings;

namespace de.fhb.oll.mediacategorizer.tools
{
    class FfmpegTool : ToolBase
    {
        public FfmpegTool(Setup setup) 
            : base(setup.Ffmpeg)
        {
        }

    }
}