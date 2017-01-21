namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using TraktApiSharp.Requests;

    internal sealed class TraktUserRecommendationHideMovieRequest : ATraktUserRecommendationHideRequest
    {
        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public override string UriTemplate => "recommendations/movies/{id}";
    }
}
