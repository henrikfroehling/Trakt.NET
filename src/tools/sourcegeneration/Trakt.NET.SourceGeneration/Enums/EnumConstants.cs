using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Enums
{
    internal static class EnumConstants
    {
        internal const string TraktEnumAttributeName = "TraktEnumAttribute";

        internal const string TraktEnumMemberAttributeName = "TraktEnumMemberAttribute";

        internal const string TraktParameterEnumAttributeName = "TraktParameterEnumAttribute";

        internal const string FullTraktEnumAttributeName = Constants.LibraryNamespace + "." + TraktEnumAttributeName;

        internal const string FullTraktEnumMemberAttributeName = Constants.LibraryNamespace + "." + TraktEnumMemberAttributeName;

        internal const string FullTraktParameterEnumAttributeName = Constants.LibraryNamespace + "." + TraktParameterEnumAttributeName;

        internal const string TraktEnumMemberPropertyDisplayName = "DisplayName";

        internal static class TrackingNames
        {
            internal const string InitialEnumExtraction = "InitialEnumExtraction";

            internal const string FilteredEnums = "FilteredEnums";

            internal const string InitialParameterEnumExtraction = "InitialParameterEnumExtraction";

            internal const string FilteredParameterEnums = "FilteredParameterEnums";
        }
    }
}
