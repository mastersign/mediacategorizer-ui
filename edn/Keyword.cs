namespace de.fhb.oll.mediacategorizer.edn
{
    public struct Keyword
    {
        private readonly string name;

        public string Name { get { return name; } }

        public Keyword(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return ":" + name;
        }
    }
}