namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncHistoryPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostShowSeason>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostShowSeason> CreateObjectReader() => new SyncHistoryPostShowSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryPostShowSeason> CreateArrayReader() => new SyncHistoryPostShowSeasonArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryPostShowSeason> CreateObjectWriter() => new SyncHistoryPostShowSeasonObjectJsonWriter();
    }
}
