namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;

    internal sealed class TraktSyncWatchlistAddRequest : ATraktSyncPostRequest<ITraktSyncWatchlistPostResponse, TraktSyncWatchlistPost>
    {
        public override string UriTemplate => "sync/watchlist";
    }
}
