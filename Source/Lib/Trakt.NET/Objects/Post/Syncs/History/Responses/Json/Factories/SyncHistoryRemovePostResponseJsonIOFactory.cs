namespace TraktNet.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncHistoryRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponse> CreateObjectReader()
            => new SyncHistoryRemovePostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryRemovePostResponse> CreateObjectWriter()
            => new SyncHistoryRemovePostResponseObjectJsonWriter();
    }
}
