namespace TraktNet.Requests.Recommendations.OAuth
{
    using Base;

    internal sealed class UserRecommendationHideShowRequest : AUserRecommendationHideRequest
    {
        public override RequestObjectType RequestObjectType => RequestObjectType.Shows;

        public override string UriTemplate => "recommendations/shows/{id}";
    }
}
