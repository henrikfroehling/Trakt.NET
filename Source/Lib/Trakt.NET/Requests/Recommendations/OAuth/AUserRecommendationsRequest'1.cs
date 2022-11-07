namespace TraktNet.Requests.Recommendations.OAuth
{
    using Base;
    using Interfaces;
    using Parameters;
    using System.Collections.Generic;

    internal abstract class AUserRecommendationsRequest<TResponseContentType> : AGetRequest<TResponseContentType>, ISupportsExtendedInfo
    {
        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public uint? Limit { get; set; }

        public bool? IgnoreCollected { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            if (IgnoreCollected.HasValue)
                uriParams.Add("ignore_collected", IgnoreCollected.Value.ToString().ToLower());

            return uriParams;
        }
    }
}
