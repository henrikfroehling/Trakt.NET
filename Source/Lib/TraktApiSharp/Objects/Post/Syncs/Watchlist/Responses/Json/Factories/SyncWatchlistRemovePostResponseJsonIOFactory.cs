namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Watchlist.Responses.Json.Reader;
    using System;

    internal class SyncWatchlistRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncWatchlistRemovePostResponse> CreateObjectReader() => new SyncWatchlistRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncWatchlistRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistRemovePostResponse)} is not supported.");
        }

        public IObjectJsonWriter<ITraktSyncWatchlistRemovePostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncWatchlistRemovePostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
