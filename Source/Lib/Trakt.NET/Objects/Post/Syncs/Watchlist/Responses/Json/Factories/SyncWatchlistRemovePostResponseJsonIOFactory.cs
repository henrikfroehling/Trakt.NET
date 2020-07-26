namespace TraktNet.Objects.Post.Syncs.Watchlist.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncWatchlistRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncWatchlistRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncWatchlistRemovePostResponse> CreateObjectReader()
            => new SyncWatchlistRemovePostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncWatchlistRemovePostResponse> CreateObjectWriter()
            => new SyncWatchlistRemovePostResponseObjectJsonWriter();
    }
}
