namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncWatchlistPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktSyncWatchlistPostResponse>
    {
        public ITraktObjectJsonReader<ITraktSyncWatchlistPostResponse> CreateObjectReader() => new TraktSyncWatchlistPostResponseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncWatchlistPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistPostResponse)} is not supported.");
        }
    }
}
