namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncHistoryPostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostShowEpisode>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostShowEpisode> CreateObjectReader() => new SyncHistoryPostShowEpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryPostShowEpisode> CreateObjectWriter() => new SyncHistoryPostShowEpisodeObjectJsonWriter();
    }
}
