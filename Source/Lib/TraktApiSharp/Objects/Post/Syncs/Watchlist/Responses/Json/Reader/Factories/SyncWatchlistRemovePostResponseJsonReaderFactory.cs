namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Syncs.Watchlist.Responses.Json.Reader;
    using System;

    internal class SyncWatchlistRemovePostResponseJsonReaderFactory : IJsonReaderFactory<ITraktSyncWatchlistRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncWatchlistRemovePostResponse> CreateObjectReader() => new SyncWatchlistRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncWatchlistRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistRemovePostResponse)} is not supported.");
        }
    }
}
