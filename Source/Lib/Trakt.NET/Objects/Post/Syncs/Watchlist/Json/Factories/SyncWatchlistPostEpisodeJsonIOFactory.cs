namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncWatchlistPostEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistPostEpisode>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPostEpisode> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncWatchlistPostEpisode)} is not supported.");

        public IArrayJsonReader<ITraktSyncWatchlistPostEpisode> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistPostEpisode)} is not supported.");

        public IObjectJsonWriter<ITraktSyncWatchlistPostEpisode> CreateObjectWriter() => new SyncWatchlistPostEpisodeObjectJsonWriter();
    }
}
