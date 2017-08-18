namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncWatchlistRemovePostResponseJsonReaderFactory : IJsonReaderFactory<ITraktSyncWatchlistRemovePostResponse>
    {
        public ITraktObjectJsonReader<ITraktSyncWatchlistRemovePostResponse> CreateObjectReader() => new TraktSyncWatchlistRemovePostResponseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncWatchlistRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistRemovePostResponse)} is not supported.");
        }
    }
}
