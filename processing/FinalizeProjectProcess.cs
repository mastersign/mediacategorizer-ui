﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace de.fhb.oll.mediacategorizer.processing
{
    class FinalizeProjectProcess : ProcessBase
    {
        public FinalizeProjectProcess(params IProcess[] dependencies)
            : base("Projekt abschließen", dependencies)
        {
            ProgressWeight = 1;
        }

        protected override void Work()
        {
            if (Directory.Exists(Project.GetWorkingDirectory()))
            {
                if (Project.Configuration.CleanupOutputDir)
                {
                    OnProgress("Arbeitsverzeichnis aufräumen");
                    Directory.Delete(Project.GetWorkingDirectory(), true);
                }
            }
        }
    }
}
