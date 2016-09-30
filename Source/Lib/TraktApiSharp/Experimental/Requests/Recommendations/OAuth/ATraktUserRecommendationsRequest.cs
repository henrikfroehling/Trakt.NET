namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktUserRecommendationsRequest<TItem> : ATraktPaginationGetRequest<TItem>, ITraktExtendedInfo
    {
        internal ATraktUserRecommendationsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public TraktExtendedOption ExtendedOption { get; set; }
    }
}
