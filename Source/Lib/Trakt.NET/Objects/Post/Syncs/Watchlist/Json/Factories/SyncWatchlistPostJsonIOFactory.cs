namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncWatchlistPostJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistPost>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPost> CreateObjectReader() => new SyncWatchlistPostObjectJsonReader();

        public IArrayJsonReader<ITraktSyncWatchlistPost> CreateArrayReader() => new SyncWatchlistPostArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncWatchlistPost> CreateObjectWriter() => new SyncWatchlistPostObjectJsonWriter();
    }
}
