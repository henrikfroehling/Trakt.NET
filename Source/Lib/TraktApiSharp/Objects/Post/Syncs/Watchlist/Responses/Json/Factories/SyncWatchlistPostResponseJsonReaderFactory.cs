namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Watchlist.Responses.Json.Reader;
    using System;

    internal class SyncWatchlistPostResponseJsonReaderFactory : IJsonIOFactory<ITraktSyncWatchlistPostResponse>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPostResponse> CreateObjectReader() => new SyncWatchlistPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncWatchlistPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistPostResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncWatchlistPostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncWatchlistPostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
