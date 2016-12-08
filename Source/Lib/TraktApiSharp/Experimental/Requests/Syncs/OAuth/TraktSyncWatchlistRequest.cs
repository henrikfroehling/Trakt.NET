namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Enums;
    using Objects.Get.Watchlist;
    using System.Collections.Generic;

    internal sealed class TraktSyncWatchlistRequest : ATraktSyncPaginationRequest<TraktWatchlistItem>
    {
        internal TraktSyncWatchlistRequest(TraktClient client) : base(client) { }

        internal TraktSyncItemType Type { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public override string UriTemplate => "sync/watchlist{/type}{?extended,page,limit}";
    }
}
