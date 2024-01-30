namespace TraktNET
{
    public readonly record struct TraktEnumToGenerate
    {
        public readonly string Name;

        public readonly string CompleteName;

        public readonly string FullyQualifiedName;

        public readonly IList<string> Values;

        public TraktEnumToGenerate(string name, string completeName, string fullyQualifiedName, IList<string> values)
        {
            Name = name;
            CompleteName = completeName;
            FullyQualifiedName = fullyQualifiedName;
            Values = values;
        }
    }
}
