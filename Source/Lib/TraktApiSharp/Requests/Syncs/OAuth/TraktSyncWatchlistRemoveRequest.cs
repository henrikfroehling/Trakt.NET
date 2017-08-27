namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;

    internal sealed class TraktSyncWatchlistRemoveRequest : ASyncPostRequest<ITraktSyncWatchlistRemovePostResponse, TraktSyncWatchlistPost>
    {
        public override string UriTemplate => "sync/watchlist/remove";
    }
}
