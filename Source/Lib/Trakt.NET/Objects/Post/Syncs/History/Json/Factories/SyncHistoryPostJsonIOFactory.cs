namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncHistoryPostJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPost>
    {
        public IObjectJsonReader<ITraktSyncHistoryPost> CreateObjectReader() => new SyncHistoryPostObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryPost> CreateObjectWriter() => new SyncHistoryPostObjectJsonWriter();
    }
}
