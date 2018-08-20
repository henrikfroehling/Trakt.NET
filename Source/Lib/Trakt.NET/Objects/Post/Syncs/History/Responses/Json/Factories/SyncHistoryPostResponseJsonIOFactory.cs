namespace TraktNet.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncHistoryPostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostResponse>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostResponse> CreateObjectReader() => new SyncHistoryPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryPostResponse> CreateArrayReader() => new SyncHistoryPostResponseArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryPostResponse> CreateObjectWriter() => new SyncHistoryPostResponseObjectJsonWriter();
    }
}
