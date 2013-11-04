using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    partial class CloudParameter
    {
        private void Initialize()
        {
            Color = System.Windows.Media.Color.FromRgb(0, 76, 204);
            BackgroundColor = System.Windows.Media.Colors.Transparent;
        }

        public override string ToString()
        {
            return "Wortwolke";
        }
    }
}
