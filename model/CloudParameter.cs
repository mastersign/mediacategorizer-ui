using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace de.fhb.oll.mediacategorizer.model
{
    partial class CloudParameter
    {
        private void Initialize()
        {
            Color = System.Windows.Media.Color.FromRgb(0, 76, 204);
            BackgroundColor = System.Windows.Media.Colors.Transparent;
            FontFamily = new System.Windows.Media.FontFamily("Calibri");
        }

        /// <summary>
        /// For XML serialization purposes only.
        /// </summary>
        [Browsable(false)]
        public string FontFamilyName
        {
            get { return FontFamily != null ? FontFamily.Source : null; }
            set { FontFamily = value == null ? null : new FontFamily(value); }
        }

        public override string ToString()
        {
            return "Wortwolke";
        }
    }
}
