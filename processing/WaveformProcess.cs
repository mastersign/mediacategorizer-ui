using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using de.fhb.oll.mediacategorizer.model;
using de.fhb.oll.mediacategorizer.tools;

namespace de.fhb.oll.mediacategorizer.processing
{
    class WaveformProcess : MultiTaskProcessBase
    {
        private WaveVizTool waveviz;

        public WaveformProcess(params IProcess[] dependencies)
            : base("Wellenform visualisieren", dependencies)
        { }

        private void InitializeTool()
        {
            if (waveviz == null)
            {
                waveviz = (WaveVizTool)ToolProvider.Create(typeof(WaveVizTool));
            }
        }

        protected override void Work()
        {
            InitializeTool();
            OnProgress("Wellenformen visualisieren...");
            var media = Project.Media.ToArray();
            RunTasks(media.Select(m => (ProcessTask)((pH, eH) => ProcessMedia(m, pH, eH))).ToArray());
        }

        private string BuildWaveformPath(Media media)
        {
            return Path.Combine(Project.GetWorkingDirectory(), string.Format("{0}.png", media.Id));
        }

        private void ProcessMedia(Media m, Action<float> progressHandler, Action<string> errorHandler)
        {
            m.WaveformFile = BuildWaveformPath(m);
            var parameter = Project.Configuration.Waveform;
            if (!File.Exists(m.WaveformFile))
            {
                if (!waveviz.GenerateWaveVisualization(m.AudioFile, m.WaveformFile,
                    parameter.Width, parameter.Height,
                    parameter.BackgroundColor, parameter.Foreground1Color,
                    parameter.Foreground2Color, parameter.LineColor))
                {
                    errorHandler("WaveViz wurde mit einem Fehler beendet");
                }
            }
            else
            {
                progressHandler(1);
            }
        }
    }
}
