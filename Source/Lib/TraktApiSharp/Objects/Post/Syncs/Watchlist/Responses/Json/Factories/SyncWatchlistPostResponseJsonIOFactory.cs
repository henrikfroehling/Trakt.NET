namespace TraktNet.Objects.Post.Syncs.Watchlist.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncWatchlistPostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistPostResponse>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPostResponse> CreateObjectReader() => new SyncWatchlistPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncWatchlistPostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistPostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktSyncWatchlistPostResponse> CreateObjectWriter() => new SyncWatchlistPostResponseObjectJsonWriter();
    }
}
