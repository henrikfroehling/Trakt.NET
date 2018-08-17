namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncWatchlistPostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistPostShowEpisode>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPostShowEpisode> CreateObjectReader() => new SyncWatchlistPostShowEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktSyncWatchlistPostShowEpisode> CreateArrayReader() => new SyncWatchlistPostShowEpisodeArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncWatchlistPostShowEpisode> CreateObjectWriter() => new SyncWatchlistPostShowEpisodeObjectJsonWriter();
    }
}
