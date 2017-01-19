namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktMovieWatchingUsersRequest : ITraktSupportsExtendedInfo
    {
        internal TraktMovieWatchingUsersRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public string UriTemplate => "movies/{id}/watching{?extended}";
    }
}
