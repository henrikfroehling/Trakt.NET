namespace TraktApiSharp.Requests.Recommendations.OAuth
{
    using Base;

    internal sealed class TraktUserRecommendationHideMovieRequest : ATraktUserRecommendationHideRequest
    {
        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public override string UriTemplate => "recommendations/movies/{id}";
    }
}
