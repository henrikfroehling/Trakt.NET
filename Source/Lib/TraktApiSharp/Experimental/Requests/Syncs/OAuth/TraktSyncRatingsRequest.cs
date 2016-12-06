namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Enums;
    using Interfaces;
    using Objects.Get.Ratings;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSyncRatingsRequest : ATraktSyncListRequest<TraktRatingsItem>, ITraktExtendedInfo
    {
        internal TraktSyncRatingsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        internal TraktRatingsItemType Type { get; set; }

        internal int[] Rating { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public override string UriTemplate => "sync/ratings{/type}{/rating}{?extended}";
    }
}
