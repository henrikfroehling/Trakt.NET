namespace TraktApiSharp.Experimental.Requests.Movies
{
    using TraktApiSharp.Requests;

    internal sealed class TraktMovieStatisticsRequest
    {
        internal TraktMovieStatisticsRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public string UriTemplate => "movies/{id}/stats";
    }
}
