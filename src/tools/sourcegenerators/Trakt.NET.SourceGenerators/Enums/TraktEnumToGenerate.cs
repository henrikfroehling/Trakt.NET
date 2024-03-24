namespace TraktNET.SourceGenerators.Enums
{
    internal readonly record struct TraktEnumMemberToGenerate
    {
        public readonly string Name;

        public readonly bool HasTraktEnumMemberAttribute;

        public readonly string JsonValue;

        public readonly string DisplayName;

        public TraktEnumMemberToGenerate(string name, bool hasTraktEnumMemberAttribute, string jsonValue, string displayName)
        {
            Name = name;
            HasTraktEnumMemberAttribute = hasTraktEnumMemberAttribute;
            JsonValue = jsonValue;
            DisplayName = displayName;
        }
    }

    internal readonly record struct TraktEnumToGenerate
    {
        public readonly string Name;

        public readonly string EnumExtensionClassName;

        public readonly bool HasFlagsAttribute;

        public readonly bool HasParameterEnumAttribute;

        public readonly string ParameterEnumAttributeValue;

        public readonly IList<TraktEnumMemberToGenerate> Values;

        public TraktEnumToGenerate(string name, string enumExtensionClassName, bool hasFlagsAttribute, bool hasParameterEnumAttribute,
            string parameterEnumAttributeValue, IList<TraktEnumMemberToGenerate> values)
        {
            Name = name;
            EnumExtensionClassName = enumExtensionClassName;
            HasFlagsAttribute = hasFlagsAttribute;
            HasParameterEnumAttribute = hasParameterEnumAttribute;
            ParameterEnumAttributeValue = parameterEnumAttributeValue;
            Values = values;
        }
    }
}
