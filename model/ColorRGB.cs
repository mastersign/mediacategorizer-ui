using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    class ColorRGB : ModelBase, ICloneable
    {
        private const float DEF_R = 0.0f;
        private const float DEF_G = 0.5f;
        private const float DEF_B = 1.0f;

        private float r;
        private float g;
        private float b;

        public ColorRGB()
        {
            r = DEF_R;
            g = DEF_G;
            b = DEF_B;
        }

        public ColorRGB(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public float R
        {
            get { return r; }
            set
            {
                if (Math.Abs(value - r) < float.Epsilon) return;
                r = value; 
                OnPropertyChanged("R");
            }
        }

        public float G
        {
            get { return g; }
            set
            {
                if (Math.Abs(value - g) < float.Epsilon) return;
                g = value;
                OnPropertyChanged("G");
            }
        }

        public float B
        {
            get { return b; }
            set
            {
                if (Math.Abs(value - b) < float.Epsilon) return;
                b = value; 
                OnPropertyChanged("B");
            }
        }

        public virtual object Clone()
        {
            return new ColorRGB(R, G, B);
        }
    }
}
