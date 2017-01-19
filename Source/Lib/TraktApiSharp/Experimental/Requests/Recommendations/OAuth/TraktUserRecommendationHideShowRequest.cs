namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using TraktApiSharp.Requests;

    internal sealed class TraktUserRecommendationHideShowRequest
    {
        internal TraktUserRecommendationHideShowRequest(TraktClient client) { }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public string UriTemplate => "recommendations/shows/{id}";
    }
}
