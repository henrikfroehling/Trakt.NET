namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;

    internal sealed class TraktSyncWatchlistAddRequest : ATraktSyncSingleItemPostRequest<TraktSyncWatchlistPostResponse, TraktSyncWatchlistPost>
    {
        internal TraktSyncWatchlistAddRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "sync/watchlist";
    }
}
