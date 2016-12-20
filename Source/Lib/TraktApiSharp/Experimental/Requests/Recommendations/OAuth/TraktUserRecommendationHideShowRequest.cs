namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using Base.Delete;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserRecommendationHideShowRequest : ATraktNoContentDeleteByIdRequest
    {
        internal TraktUserRecommendationHideShowRequest(TraktClient client) : base(client) { }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "recommendations/shows/{id}";
    }
}
