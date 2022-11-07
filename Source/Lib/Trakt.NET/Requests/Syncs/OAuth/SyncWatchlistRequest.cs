namespace TraktNet.Requests.Syncs.OAuth
{
    using Enums;
    using Interfaces;
    using Objects.Get.Watchlist;
    using Parameters;
    using System.Collections.Generic;
    using TraktNet.Parameters;

    internal sealed class SyncWatchlistRequest : ASyncGetRequest<ITraktWatchlistItem>, ISupportsExtendedInfo, ISupportsPagination
    {
        internal TraktSyncItemType Type { get; set; }

        public TraktWatchlistSortOrder Sort { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override string UriTemplate => "sync/watchlist{/type}{/sort}{?extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (Type != null && Type != TraktSyncItemType.Unspecified)
            {
                uriParams.Add("type", Type.UriName);

                if (Sort != null && Sort != TraktWatchlistSortOrder.Unspecified)
                    uriParams.Add("sort", Sort.UriName);
            }

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
