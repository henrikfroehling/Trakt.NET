using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Enums
{
    internal static class EnumConstants
    {
        internal const string EnumsNamespace = Constants.Namespace + ".Enums";

        internal const string TraktEnumAttributeName = "TraktEnumAttribute";

        internal const string TraktEnumMemberAttributeName = "TraktEnumMemberAttribute";

        internal const string TraktParameterEnumAttributeName = "TraktParameterEnumAttribute";

        internal const string FullTraktEnumAttributeName = EnumsNamespace + "." + TraktEnumAttributeName;

        internal const string FullTraktEnumMemberAttributeName = EnumsNamespace + "." + TraktEnumMemberAttributeName;

        internal const string FullTraktParameterEnumAttributeName = EnumsNamespace + "." + TraktParameterEnumAttributeName;

        internal const string GeneratedTraktEnumAttributeFilename = TraktEnumAttributeName + Constants.GeneratedFilenameSuffix;

        internal const string GeneratedTraktEnumMemberAttributeFilename = TraktEnumMemberAttributeName + Constants.GeneratedFilenameSuffix;

        internal const string GeneratedTraktParameterEnumAttributeFilename = TraktParameterEnumAttributeName + Constants.GeneratedFilenameSuffix;

        internal const string GeneratedTraktEnumFileExtension = "EnumExtensions" + Constants.GeneratedFilenameSuffix;

        internal const string TraktEnumAttribute = Constants.Header + @"
namespace " + EnumsNamespace + @"
{
    /// <summary>Provides extension methods and a Json converter for an enum.</summary>
" + Constants.ExcludeCodeCoverage + @"
    [global::System.AttributeUsage(global::System.AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
    public class " + TraktEnumAttributeName + @" : global::System.Attribute
    {
    }
}
";

        internal const string TraktEnumMemberJsonValuePropertyDisplayName = "DisplayName";

        internal const string TraktEnumMemberJsonValueAttribute = Constants.Header + @"
namespace " + EnumsNamespace + @"
{
    /// <summary>Provides a custom Json value and optional display name for an enum member.</summary>
" + Constants.ExcludeCodeCoverage + @"
    [global::System.AttributeUsage(global::System.AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class " + TraktEnumMemberAttributeName + @" : global::System.Attribute
    {
        public " + TraktEnumMemberAttributeName + @"(string jsonValue)
            => JsonValue = jsonValue;

        public string JsonValue { get; }
        public string? " + TraktEnumMemberJsonValuePropertyDisplayName + @" { get; set; }
    }
}
";

        internal const string TraktParameterEnumAttribute = Constants.Header + @"
namespace " + EnumsNamespace + @"
{
    ///<summary>Provides extension methods for an enum which can be used as a request parameter.</summary>
" + Constants.ExcludeCodeCoverage + @"
    [global::System.AttributeUsage(global::System.AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
    public sealed class " + TraktParameterEnumAttributeName + @" : " + TraktEnumAttributeName +
@"
    {
        public " + TraktParameterEnumAttributeName + @"(string uriParameterName)
            => UriParameterName = uriParameterName;

        public string UriParameterName { get; }
    }
}
";

        internal static class TrackingNames
        {
            internal const string InitialEnumExtraction = "InitialEnumExtraction";

            internal const string FilteredEnums = "FilteredEnums";

            internal const string InitialParameterEnumExtraction = "InitialParameterEnumExtraction";

            internal const string FilteredParameterEnums = "FilteredParameterEnums";
        }
    }
}
