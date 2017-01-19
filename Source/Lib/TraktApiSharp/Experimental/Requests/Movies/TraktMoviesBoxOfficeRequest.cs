namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktMoviesBoxOfficeRequest : ITraktSupportsExtendedInfo
    {
        internal TraktMoviesBoxOfficeRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public string UriTemplate => "movies/boxoffice{?extended}";
    }
}
