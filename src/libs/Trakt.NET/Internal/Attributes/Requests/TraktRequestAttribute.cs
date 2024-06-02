namespace TraktNET
{
    internal abstract class TraktRequestAttribute(HttpMethod method, string path) : Attribute
    {
        public HttpMethod Method { get; } = method;

        public string Path { get; } = path;

        public bool SupportsExtendedInfo { get; set; }

        public bool SupportsPagination { get; set; }

        public TraktOAuthRequirement OAuthRequirement { get; set; }
    }
}
