namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Get.Watchlist;

    internal sealed class TraktSyncWatchlistRequest : ATraktSyncPaginationRequest<TraktWatchlistItem>
    {
        internal TraktSyncWatchlistRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "sync/watchlist{/type}{?extended,page,limit}";
    }
}
