using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    class ColorRGBA : ColorRGB
    {
        private const float DEF_A = 1.0f;

        private float a;

        public ColorRGBA()
        {
            a = DEF_A;
        }

        public ColorRGBA(float r, float g, float b, float a) : base(r, g, b)
        {
            this.a = a;
        }

        public float A
        {
            get { return a; }
            set
            {
                if (Math.Abs(value - a) < float.Epsilon) return;
                a = value; 
                OnPropertyChanged("A");
            }
        }

        public override object Clone()
        {
            return new ColorRGBA(R, G, B, A);
        }
    }
}
