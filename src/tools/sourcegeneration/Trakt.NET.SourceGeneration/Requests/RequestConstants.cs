using TraktNET.SourceGeneration.Common;

namespace TraktNET.SourceGeneration.Requests
{
    internal static class RequestConstants
    {
        internal const string RequestsNamespace = Constants.Namespace + ".Requests";

        internal const string TraktOAuthRequirementName = "TraktOAuthRequirement";

        internal const string TraktRequestAttributeName = "TraktRequestAttribute";

        internal const string TraktGetRequestAttributeName = "TraktGetRequestAttribute";

        internal const string TraktPostRequestAttributeName = "TraktPostRequestAttribute";

        internal const string TraktPutRequestAttributeName = "TraktPutRequestAttribute";

        internal const string TraktDeleteRequestAttributeName = "TraktDeleteRequestAttribute";

        internal const string FullTraktOAuthRequirementName = RequestsNamespace + "." + TraktOAuthRequirementName;

        internal const string FullTraktRequestAttributeName = RequestsNamespace + "." + TraktRequestAttributeName;

        internal const string FullTraktGetRequestAttributeName = RequestsNamespace + "." + TraktGetRequestAttributeName;

        internal const string FullTraktPostRequestAttributeName = RequestsNamespace + "." + TraktPostRequestAttributeName;

        internal const string FullTraktPutRequestAttributeName = RequestsNamespace + "." + TraktPutRequestAttributeName;

        internal const string FullTraktDeleteRequestAttributeName = RequestsNamespace + "." + TraktDeleteRequestAttributeName;

        internal const string GeneratedTraktOAuthRequirementFilename = TraktOAuthRequirementName + Constants.GeneratedFilenameSuffix;

        internal const string GeneratedTraktRequestAttributeFilename = TraktRequestAttributeName + Constants.GeneratedFilenameSuffix;

        internal const string GeneratedTraktGetRequestAttributeFilename = TraktGetRequestAttributeName + Constants.GeneratedFilenameSuffix;

        internal const string GeneratedTraktPostRequestAttributeFilename = TraktPostRequestAttributeName + Constants.GeneratedFilenameSuffix;

        internal const string GeneratedTraktPutRequestAttributeFilename = TraktPutRequestAttributeName + Constants.GeneratedFilenameSuffix;

        internal const string GeneratedTraktDeleteRequestAttributeFilename = TraktDeleteRequestAttributeName + Constants.GeneratedFilenameSuffix;

        internal const string TraktOAuthRequirement = Constants.Header + @"
namespace " + RequestsNamespace + @"
{
    ///<summary>Specifies the OAuth requirement for Trakt requests.</summary>
    public enum TraktOAuthRequirement
    {
        NotRequired,
        Optional,
        OptionalButMightBeRequired,
        Required
    }
}
";

        internal const string TraktRequestAttribute = Constants.Header + @"
namespace " + RequestsNamespace + @"
{
" + Constants.ExcludeCodeCoverage + @"
    public abstract class " + TraktRequestAttributeName + @" : global::System.Attribute
    {
        public " + TraktRequestAttributeName + @"(HttpMethod method, string path)
        {
            Method = method;
            Path = path;
        }

        public HttpMethod Method { get; }

        public string Path { get; }

        public bool SupportsExtendedInfo { get; set; }

        public bool SupportsPagination { get; set; }

        public bool SupportsFilter { get; set; }

        public TraktOAuthRequirement OAuthRequirement { get; set; }
    }
}
";

        internal const string TraktGetRequestAttribute = Constants.Header + @"
namespace " + RequestsNamespace + @"
{
    ///<summary>Creates a Trakt GET request.</summary>
" + Constants.ExcludeCodeCoverage + @"
    [global::System.AttributeUsage(global::System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class " + TraktGetRequestAttributeName + @" : " + TraktRequestAttributeName + @"
    {
        public " + TraktGetRequestAttributeName + @"(string path) : base(HttpMethod.Get, path) {}
    }
}
";

        internal const string TraktPostRequestAttribute = Constants.Header + @"
namespace " + RequestsNamespace + @"
{
    ///<summary>Creates a Trakt POST request.</summary>
" + Constants.ExcludeCodeCoverage + @"
    [global::System.AttributeUsage(global::System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class " + TraktPostRequestAttributeName + @" : " + TraktRequestAttributeName + @"
    {
        public " + TraktPostRequestAttributeName + @"(string path) : base(HttpMethod.Post, path) {}
    }
}
";

        internal const string TraktPutRequestAttribute = Constants.Header + @"
namespace " + RequestsNamespace + @"
{
    ///<summary>Creates a Trakt PUT request.</summary>
" + Constants.ExcludeCodeCoverage + @"
    [global::System.AttributeUsage(global::System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class " + TraktPutRequestAttributeName + @" : " + TraktRequestAttributeName + @"
    {
        public " + TraktPutRequestAttributeName + @"(string path) : base(HttpMethod.Put, path) {}
    }
}
";

        internal const string TraktDeleteRequestAttribute = Constants.Header + @"
namespace " + RequestsNamespace + @"
{
    ///<summary>Creates a Trakt DELETE request.</summary>
" + Constants.ExcludeCodeCoverage + @"
    [global::System.AttributeUsage(global::System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class " + TraktDeleteRequestAttributeName + @" : " + TraktRequestAttributeName + @"
    {
        public " + TraktDeleteRequestAttributeName + @"(string path) : base(HttpMethod.Delete, path) {}
    }
}
";
    }
}
