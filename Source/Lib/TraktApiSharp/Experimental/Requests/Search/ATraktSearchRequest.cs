namespace TraktApiSharp.Experimental.Requests.Search
{
    using Enums;
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktSearchRequest : ITraktSupportsExtendedInfo
    {
        internal ATraktSearchRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        internal TraktSearchResultType ResultTypes { get; set; }
    }
}
