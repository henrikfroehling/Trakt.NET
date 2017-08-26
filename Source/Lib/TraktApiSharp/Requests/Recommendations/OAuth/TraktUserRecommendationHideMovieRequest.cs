namespace TraktApiSharp.Requests.Recommendations.OAuth
{
    using Base;

    internal sealed class TraktUserRecommendationHideMovieRequest : AUserRecommendationHideRequest
    {
        public override RequestObjectType RequestObjectType => RequestObjectType.Movies;

        public override string UriTemplate => "recommendations/movies/{id}";
    }
}
