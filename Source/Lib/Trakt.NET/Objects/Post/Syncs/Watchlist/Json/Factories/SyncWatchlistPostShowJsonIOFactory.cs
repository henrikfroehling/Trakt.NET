namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncWatchlistPostShowJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistPostShow>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPostShow> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncWatchlistPostShow)} is not supported.");

        public IArrayJsonReader<ITraktSyncWatchlistPostShow> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistPostShow)} is not supported.");

        public IObjectJsonWriter<ITraktSyncWatchlistPostShow> CreateObjectWriter() => new SyncWatchlistPostShowObjectJsonWriter();
    }
}
