namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using TraktApiSharp.Requests;

    internal sealed class TraktUserRecommendationHideMovieRequest
    {
        internal TraktUserRecommendationHideMovieRequest(TraktClient client) { }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public string UriTemplate => "recommendations/movies/{id}";
    }
}
