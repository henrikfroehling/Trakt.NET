namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Enums;
    using Objects.Get.Watchlist;

    internal sealed class TraktSyncWatchlistRequest : ATraktSyncPaginationRequest<TraktWatchlistItem>
    {
        internal TraktSyncWatchlistRequest(TraktClient client) : base(client) { }

        internal TraktSyncItemType Type { get; set; }

        public override string UriTemplate => "sync/watchlist{/type}{?extended,page,limit}";
    }
}
