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
            Color = new ColorRGBA {R=0.0f, G=0.3f, B=0.8f, A=1.0f};
            BackgroundColor = new ColorRGBA {R = 0.0f, G = 0.0f, B = 0.0f, A = 0.0f};
        }
    }
}
