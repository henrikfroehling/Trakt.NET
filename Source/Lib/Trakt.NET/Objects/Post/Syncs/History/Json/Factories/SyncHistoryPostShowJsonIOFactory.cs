namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncHistoryPostShowJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostShow>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostShow> CreateObjectReader() => new SyncHistoryPostShowObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryPostShow> CreateArrayReader() => new SyncHistoryPostShowArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryPostShow> CreateObjectWriter() => new SyncHistoryPostShowObjectJsonWriter();
    }
}
