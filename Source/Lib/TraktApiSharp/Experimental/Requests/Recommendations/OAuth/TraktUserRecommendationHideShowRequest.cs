namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using TraktApiSharp.Requests;

    internal sealed class TraktUserRecommendationHideShowRequest : ATraktUserRecommendationHideRequest
    {
        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "recommendations/shows/{id}";
    }
}
