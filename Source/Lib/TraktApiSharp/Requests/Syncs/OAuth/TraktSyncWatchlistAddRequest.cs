namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;

    internal sealed class TraktSyncWatchlistAddRequest : ASyncPostRequest<ITraktSyncWatchlistPostResponse, TraktSyncWatchlistPost>
    {
        public override string UriTemplate => "sync/watchlist";
    }
}
