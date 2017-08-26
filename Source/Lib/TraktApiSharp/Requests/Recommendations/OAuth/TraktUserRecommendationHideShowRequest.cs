namespace TraktApiSharp.Requests.Recommendations.OAuth
{
    using Base;

    internal sealed class TraktUserRecommendationHideShowRequest : AUserRecommendationHideRequest
    {
        public override RequestObjectType RequestObjectType => RequestObjectType.Shows;

        public override string UriTemplate => "recommendations/shows/{id}";
    }
}
