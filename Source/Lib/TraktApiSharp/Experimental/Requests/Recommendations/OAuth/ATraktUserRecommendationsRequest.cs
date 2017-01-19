namespace TraktApiSharp.Experimental.Requests.Recommendations.OAuth
{
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktUserRecommendationsRequest<TItem> : ITraktSupportsExtendedInfo
    {
        internal ATraktUserRecommendationsRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
