using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Requests
{
    internal static class RequestConstants
    {
        internal const string TraktOAuthRequirementName = "TraktOAuthRequirement";

        internal const string TraktRequestAttributeName = "TraktRequestAttribute";

        internal const string TraktGetRequestAttributeName = "TraktGetRequestAttribute";

        internal const string TraktPostRequestAttributeName = "TraktPostRequestAttribute";

        internal const string TraktPutRequestAttributeName = "TraktPutRequestAttribute";

        internal const string TraktDeleteRequestAttributeName = "TraktDeleteRequestAttribute";

        internal const string TraktExtendedInfoName = "TraktExtendedInfo";

        internal const string FullTraktExtendedInfoName = Constants.LibraryNamespace + "." + TraktExtendedInfoName;

        internal const string FullTraktOAuthRequirementName = Constants.LibraryNamespace + "." + TraktOAuthRequirementName;

        internal const string FullTraktRequestAttributeName = Constants.LibraryNamespace + "." + TraktRequestAttributeName;

        internal const string FullTraktGetRequestAttributeName = Constants.LibraryNamespace + "." + TraktGetRequestAttributeName;

        internal const string FullTraktPostRequestAttributeName = Constants.LibraryNamespace + "." + TraktPostRequestAttributeName;

        internal const string FullTraktPutRequestAttributeName = Constants.LibraryNamespace + "." + TraktPutRequestAttributeName;

        internal const string FullTraktDeleteRequestAttributeName = Constants.LibraryNamespace + "." + TraktDeleteRequestAttributeName;

        internal const string TraktRequestPropertySupportsExtendedInfoName = "SupportsExtendedInfo";

        internal const string TraktRequestPropertySupportsPaginationName = "SupportsPagination";

        internal const string TraktRequestPropertyOAuthRequirementName = "OAuthRequirement";

        internal static class TrackingNames
        {
            internal const string InitialGetRequestsExtraction = "InitialGetRequestsExtraction";

            internal const string FilteredGetRequests = "FilteredGetRequests";

            internal const string InitialPostRequestsExtraction = "InitialPostRequestsExtraction";

            internal const string FilteredPostRequests = "FilteredPostRequests";

            internal const string InitialPutRequestsExtraction = "InitialPutRequestsExtraction";

            internal const string FilteredPutRequests = "FilteredPutRequests";

            internal const string InitialDeleteRequestsExtraction = "InitialDeleteRequestsExtraction";

            internal const string FilteredDeleteRequests = "FilteredDeleteRequests";
        }
    }
}
