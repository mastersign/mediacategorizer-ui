using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using de.fhb.oll.mediacategorizer.settings;

namespace de.fhb.oll.mediacategorizer.tools
{
    class WaveVizTool : ToolBase
    {
        public WaveVizTool(Setup setup)
            : base(setup.WaveViz)
        { }

        private static string FormatColor(Color c)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", c.R, c.G, c.B, c.A);
        }

        public bool GenerateWaveVisualization(
            string sourceWaveFile, string targetPngFile,
            int width, int height, 
            Color background, Color foreground1, Color foreground2, Color lineColor)
        {
            var arguments = string.Format("\"{0}\" \"{1}\" {2} {3} {4} {5} {6} {7}",
                sourceWaveFile, targetPngFile, width, height,
                FormatColor(background), FormatColor(foreground1),
                FormatColor(foreground2), FormatColor(lineColor));

            var pi = new ProcessStartInfo(ToolPath, arguments);
            pi.CreateNoWindow = true;
            pi.UseShellExecute = false;
            var p = Process.Start(pi);
            p.WaitForExit();
            return p.ExitCode == 0;
        }
    }
}
