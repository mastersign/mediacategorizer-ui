using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    partial class Category
    {
        public int ResourceCount { get { return Resources != null ? Resources.Count : 0; } }
    }
}
