namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncHistoryPostSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostSeason>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostSeason> CreateObjectReader() => new SyncHistoryPostSeasonObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryPostSeason> CreateObjectWriter() => new SyncHistoryPostSeasonObjectJsonWriter();
    }
}
