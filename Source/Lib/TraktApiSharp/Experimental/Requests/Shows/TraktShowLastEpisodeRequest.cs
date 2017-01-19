namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktShowLastEpisodeRequest : ITraktSupportsExtendedInfo
    {
        internal TraktShowLastEpisodeRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public string UriTemplate => "shows/{id}/last_episode{?extended}";
    }
}
