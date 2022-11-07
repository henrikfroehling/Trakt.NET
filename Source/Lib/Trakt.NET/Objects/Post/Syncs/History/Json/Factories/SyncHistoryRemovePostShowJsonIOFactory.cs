namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Syncs.History.Json.Reader;
    using TraktNet.Objects.Post.Syncs.History.Json.Writer;

    internal class SyncHistoryRemovePostShowJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostShow>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostShow> CreateObjectReader() => new SyncHistoryRemovePostShowObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryRemovePostShow> CreateObjectWriter() => new SyncHistoryRemovePostShowObjectJsonWriter();
    }
}
