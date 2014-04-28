using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.model
{
    partial class Profile
    {
        public static Profile FromTuple(Tuple<Guid, string> profile)
        {
            return new Profile { Id = profile.Item1, Name = profile.Item2 };
        }
    }
}
