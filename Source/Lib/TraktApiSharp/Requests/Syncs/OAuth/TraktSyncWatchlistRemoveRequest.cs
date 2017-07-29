namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;

    internal sealed class TraktSyncWatchlistRemoveRequest : ATraktSyncPostRequest<ITraktSyncWatchlistRemovePostResponse, TraktSyncWatchlistPost>
    {
        public override string UriTemplate => "sync/watchlist/remove";
    }
}
