namespace TraktNet.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;

    internal sealed class SyncWatchlistRemoveRequest : ASyncPostRequest<ITraktSyncWatchlistRemovePostResponse, ITraktSyncWatchlistRemovePost>
    {
        public override string UriTemplate => "sync/watchlist/remove";
    }
}
