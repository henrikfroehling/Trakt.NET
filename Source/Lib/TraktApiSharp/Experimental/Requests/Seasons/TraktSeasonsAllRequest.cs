namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSeasonsAllRequest : ITraktSupportsExtendedInfo
    {
        internal TraktSeasonsAllRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public string UriTemplate => "shows/{id}/seasons{?extended}";
    }
}
