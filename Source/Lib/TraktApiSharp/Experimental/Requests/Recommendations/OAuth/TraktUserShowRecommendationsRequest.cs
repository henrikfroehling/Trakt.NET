namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using Objects.Get.Shows;

    internal sealed class TraktUserShowRecommendationsRequest : ATraktUserRecommendationsRequest<TraktShow>
    {
        public TraktUserShowRecommendationsRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "recommendations/shows{?extended,limit}";
    }
}
