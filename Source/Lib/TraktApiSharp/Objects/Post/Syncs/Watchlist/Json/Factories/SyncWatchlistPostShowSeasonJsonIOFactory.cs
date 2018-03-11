namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncWatchlistPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistPostShowSeason>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPostShowSeason> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncWatchlistPostShowSeason)} is not supported.");

        public IArrayJsonReader<ITraktSyncWatchlistPostShowSeason> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistPostShowSeason)} is not supported.");

        public IObjectJsonWriter<ITraktSyncWatchlistPostShowSeason> CreateObjectWriter() => new SyncWatchlistPostShowSeasonObjectJsonWriter();
    }
}
