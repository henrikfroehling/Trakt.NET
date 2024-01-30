namespace TraktNET
{
    public readonly record struct TraktEnumToGenerate
    {
        public readonly string Name;

        public readonly string EnumExtensionClassName;

        public readonly IList<string> Values;

        public TraktEnumToGenerate(string name, string enumExtensionClassName, IList<string> values)
        {
            Name = name;
            EnumExtensionClassName = enumExtensionClassName;
            Values = values;
        }
    }
}
