namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncHistoryPostEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostEpisode>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostEpisode> CreateObjectReader() => new SyncHistoryPostEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryPostEpisode> CreateArrayReader() => new SyncHistoryPostEpisodeArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryPostEpisode> CreateObjectWriter() => new SyncHistoryPostEpisodeObjectJsonWriter();
    }
}
