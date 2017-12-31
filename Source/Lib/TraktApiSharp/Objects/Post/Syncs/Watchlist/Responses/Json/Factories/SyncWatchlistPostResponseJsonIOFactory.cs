namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Watchlist.Responses.Json.Reader;
    using System;

    internal class SyncWatchlistPostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistPostResponse>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPostResponse> CreateObjectReader() => new SyncWatchlistPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncWatchlistPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistPostResponse)} is not supported.");
        }

        public IObjectJsonWriter<ITraktSyncWatchlistPostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncWatchlistPostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
