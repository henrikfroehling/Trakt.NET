namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncWatchlistPostMovieJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistPostMovie>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPostMovie> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncWatchlistPostMovie)} is not supported.");

        public IArrayJsonReader<ITraktSyncWatchlistPostMovie> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistPostMovie)} is not supported.");

        public IObjectJsonWriter<ITraktSyncWatchlistPostMovie> CreateObjectWriter() => new SyncWatchlistPostMovieObjectJsonWriter();
    }
}
