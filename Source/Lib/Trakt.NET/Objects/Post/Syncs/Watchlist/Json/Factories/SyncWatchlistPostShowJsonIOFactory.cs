namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncWatchlistPostShowJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistPostShow>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPostShow> CreateObjectReader() => new SyncWatchlistPostShowObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncWatchlistPostShow> CreateObjectWriter() => new SyncWatchlistPostShowObjectJsonWriter();
    }
}
