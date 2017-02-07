namespace TraktApiSharp.Requests.Recommendations.OAuth
{
    using Base;

    internal sealed class TraktUserRecommendationHideShowRequest : ATraktUserRecommendationHideRequest
    {
        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "recommendations/shows/{id}";
    }
}
