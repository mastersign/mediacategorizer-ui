using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    partial class WaveformParameter
    {
        private void Initialize()
        {
            BackgroundColor = System.Windows.Media.Colors.White;
            Foreground1Color = System.Windows.Media.Color.FromRgb(0, 76, 204);
            Foreground2Color = System.Windows.Media.Color.FromRgb(127, 180, 255);
            LineColor = System.Windows.Media.Color.FromRgb(0, 48, 128);

            PassiveBackgroundColor = System.Windows.Media.Colors.White;
            PassiveForeground1Color = System.Windows.Media.Color.FromRgb(160, 160, 160);
            PassiveForeground2Color = System.Windows.Media.Color.FromRgb(208, 208, 208);
            PassiveLineColor = System.Windows.Media.Color.FromRgb(128, 128, 128);
        }

        public override string ToString()
        {
            return "Wellenformvisualisierung";
        }
    }
}
