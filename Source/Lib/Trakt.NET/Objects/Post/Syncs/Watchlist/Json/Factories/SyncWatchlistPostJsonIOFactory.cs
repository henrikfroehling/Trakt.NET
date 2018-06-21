namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncWatchlistPostJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistPost>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncWatchlistPost)} is not supported.");

        public IArrayJsonReader<ITraktSyncWatchlistPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistPost)} is not supported.");

        public IObjectJsonWriter<ITraktSyncWatchlistPost> CreateObjectWriter() => new SyncWatchlistPostObjectJsonWriter();
    }
}
