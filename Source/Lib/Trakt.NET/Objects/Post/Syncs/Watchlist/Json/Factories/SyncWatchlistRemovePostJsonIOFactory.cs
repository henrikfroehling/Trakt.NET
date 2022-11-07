namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncWatchlistRemovePostJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistRemovePost>
    {
        public IObjectJsonReader<ITraktSyncWatchlistRemovePost> CreateObjectReader() => new SyncWatchlistRemovePostObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncWatchlistRemovePost> CreateObjectWriter() => new SyncWatchlistRemovePostObjectJsonWriter();
    }
}
