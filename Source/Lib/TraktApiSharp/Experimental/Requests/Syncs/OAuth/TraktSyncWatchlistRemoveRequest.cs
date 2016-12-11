namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;

    internal sealed class TraktSyncWatchlistRemoveRequest : ATraktSyncSingleItemPostRequest<TraktSyncWatchlistRemovePostResponse, TraktSyncWatchlistPost>
    {
        internal TraktSyncWatchlistRemoveRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "sync/watchlist/remove";
    }
}
