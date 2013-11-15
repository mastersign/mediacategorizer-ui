using System.Collections;

namespace de.fhb.oll.mediacategorizer.edn
{
    public class EdnVector : IEdnWritable
    {
        private readonly IEnumerable enumerable;
        private readonly bool oneItemPerLine;

        public EdnVector(IEnumerable enumerable, bool oneItemPerLine = false)
        {
            this.enumerable = enumerable;
            this.oneItemPerLine = oneItemPerLine;
        }

        public void WriteTo(EdnWriter w)
        {
            w.WriteVector(enumerable, oneItemPerLine);
        }
    }
}