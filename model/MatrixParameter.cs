using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.fhb.oll.mediacategorizer.model
{
    partial class MatrixParameter
    {
        private void Initialize()
        {
            Color = System.Windows.Media.Color.FromRgb(0, 76, 204);
        }

        public override string ToString()
        {
            return "Übereinstimmungsmatrix";
        }
    }
}
