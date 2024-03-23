namespace TraktNET.SourceGenerators.Enums
{
    internal readonly record struct TraktEnumMemberToGenerate
    {
        public readonly string Name;

        public readonly bool HasAttribute;

        public readonly string JsonValue;

        public readonly string DisplayName;

        public TraktEnumMemberToGenerate(string name, bool hasAttribute, string jsonValue, string displayName)
        {
            Name = name;
            HasAttribute = hasAttribute;
            JsonValue = jsonValue;
            DisplayName = displayName;
        }
    }

    internal readonly record struct TraktEnumToGenerate
    {
        public readonly string Name;

        public readonly string EnumExtensionClassName;

        public readonly IList<TraktEnumMemberToGenerate> Values;

        public TraktEnumToGenerate(string name, string enumExtensionClassName, IList<TraktEnumMemberToGenerate> values)
        {
            Name = name;
            EnumExtensionClassName = enumExtensionClassName;
            Values = values;
        }
    }
}
