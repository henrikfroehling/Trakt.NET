namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    internal class SyncWatchlistPostObjectJsonReader : ASyncWatchlistPostObjectJsonReader<ITraktSyncWatchlistPost>
    {
        protected override ITraktSyncWatchlistPost CreateInstance() => new TraktSyncWatchlistPost();
    }
}
