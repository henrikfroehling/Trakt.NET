namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    internal class SyncWatchlistRemovePostObjectJsonReader : ASyncWatchlistPostObjectJsonReader<ITraktSyncWatchlistRemovePost>
    {
        protected override ITraktSyncWatchlistRemovePost CreateInstance() => new TraktSyncWatchlistRemovePost();
    }
}
