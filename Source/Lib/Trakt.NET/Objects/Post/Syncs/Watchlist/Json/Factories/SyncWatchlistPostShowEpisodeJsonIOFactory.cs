namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncWatchlistPostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistPostShowEpisode>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPostShowEpisode> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncWatchlistPostShowEpisode)} is not supported.");

        public IArrayJsonReader<ITraktSyncWatchlistPostShowEpisode> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistPostShowEpisode)} is not supported.");

        public IObjectJsonWriter<ITraktSyncWatchlistPostShowEpisode> CreateObjectWriter() => new SyncWatchlistPostShowEpisodeObjectJsonWriter();
    }
}
