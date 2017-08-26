namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Enums;
    using Interfaces;
    using Objects.Get.Watchlist;
    using Parameters;
    using System.Collections.Generic;

    internal sealed class TraktSyncWatchlistRequest : ATraktSyncGetRequest<ITraktWatchlistItem>, ISupportsExtendedInfo, ITraktSupportsPagination
    {
        internal TraktSyncItemType Type { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override string UriTemplate => "sync/watchlist{/type}{?extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (Type != null && Type != TraktSyncItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }
    }
}
