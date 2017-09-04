namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class SyncWatchlistPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktSyncWatchlistPostResponse>
    {
        public IObjectJsonReader<ITraktSyncWatchlistPostResponse> CreateObjectReader() => new SyncWatchlistPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncWatchlistPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistPostResponse)} is not supported.");
        }
    }
}
