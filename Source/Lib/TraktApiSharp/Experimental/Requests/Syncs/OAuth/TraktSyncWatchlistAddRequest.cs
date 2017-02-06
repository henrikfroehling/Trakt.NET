namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;

    internal sealed class TraktSyncWatchlistAddRequest : ATraktSyncPostRequest<TraktSyncWatchlistPostResponse, TraktSyncWatchlistPost>
    {
        public override string UriTemplate => "sync/watchlist";
    }
}
