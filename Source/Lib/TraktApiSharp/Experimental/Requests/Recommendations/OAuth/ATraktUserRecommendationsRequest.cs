namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using Base.Get;

    internal abstract class ATraktUserRecommendationsRequest<TItem> : ATraktPaginationGetRequest<TItem>
    {
        public ATraktUserRecommendationsRequest(TraktClient client) : base(client) { }
    }
}
