namespace TraktNET.SourceGenerators.Enums
{
    internal static class EnumConstants
    {
        internal const string TraktEnumAttributeName = "TraktEnumAttribute";

        internal const string TraktEnumMemberJsonValueAttributeName = "TraktEnumMemberJsonValueAttribute";

        internal const string FullTraktEnumAttributeName = Constants.Namespace + "." + TraktEnumAttributeName;

        internal const string FullTraktEnumMemberJsonValueAttributeName = Constants.Namespace + "." + TraktEnumMemberJsonValueAttributeName;

        internal const string GeneratedTraktEnumAttributeFilename = TraktEnumAttributeName + ".g.cs";

        internal const string GeneratedTraktEnumMemberJsonValueAttributeFilename = TraktEnumMemberJsonValueAttributeName + ".g.cs";

        internal const string GeneratedTraktEnumFileExtension = "EnumExtensions.g.cs";

        internal const string TraktEnumAttribute = Constants.Header + @"
namespace " + Constants.Namespace + @"
{
    /// <summary>Provides extension methods and a Json converter for an enum.</summary>
" + Constants.ExcludeCodeCoverage + @"
    [global::System.AttributeUsage(global::System.AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
    public sealed class " + TraktEnumAttributeName + @" : global::System.Attribute
    {
    }
}
";

        internal const string TraktEnumMemberJsonValuePropertyDisplayName = "DisplayName";

        internal const string TraktEnumMemberJsonValueAttribute = Constants.Header + @"
namespace " + Constants.Namespace + @"
{
    /// <summary>Provides a custom Json value and optional display name for an enum member.</summary>
" + Constants.ExcludeCodeCoverage + @"
    [global::System.AttributeUsage(global::System.AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class " + TraktEnumMemberJsonValueAttributeName + @": global::System.Attribute
    {
        private string _jsonValue;

        public " + TraktEnumMemberJsonValueAttributeName + @"(string jsonValue)
        {
            _jsonValue = jsonValue;
        }

        public string JsonValue => _jsonValue;
        public string? " + TraktEnumMemberJsonValuePropertyDisplayName + @" { get; set; }
    }
}
";

        internal static class TrackingNames
        {
            internal const string InitialEnumExtraction = "InitialEnumExtraction";

            internal const string NullFilteredEnums = "NullFilteredEnums";
        }
    }
}
