namespace TraktNet.Requests.Recommendations.OAuth
{
    using Base;
    using Interfaces;
    using Parameters;
    using System.Collections.Generic;

    internal abstract class AUserRecommendationsRequest<TResponseContentType> : AGetRequest<TResponseContentType>, ISupportsExtendedInfo, ISupportsPagination
    {
        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public bool? IgnoreCollected { get; set; }

        public bool? IgnoreWatchlisted { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            if (IgnoreCollected.HasValue)
                uriParams.Add("ignore_collected", IgnoreCollected.Value.ToString().ToLower());

            if (IgnoreWatchlisted.HasValue)
                uriParams.Add("ignore_watchlisted", IgnoreWatchlisted.Value.ToString().ToLower());

            return uriParams;
        }
    }
}
