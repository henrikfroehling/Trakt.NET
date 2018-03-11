namespace TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncWatchlistRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncWatchlistRemovePostResponse> CreateObjectReader()
            => new SyncWatchlistRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncWatchlistRemovePostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncWatchlistRemovePostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktSyncWatchlistRemovePostResponse> CreateObjectWriter()
            => new SyncWatchlistRemovePostResponseObjectJsonWriter();
    }
}
