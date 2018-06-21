namespace TraktNet.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;

    internal sealed class SyncWatchlistAddRequest : ASyncPostRequest<ITraktSyncWatchlistPostResponse, ITraktSyncWatchlistPost>
    {
        public override string UriTemplate => "sync/watchlist";
    }
}
