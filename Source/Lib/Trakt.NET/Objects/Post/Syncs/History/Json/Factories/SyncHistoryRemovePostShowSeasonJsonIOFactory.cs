namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Syncs.History.Json.Reader;
    using TraktNet.Objects.Post.Syncs.History.Json.Writer;

    internal class SyncHistoryRemovePostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostShowSeason>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostShowSeason> CreateObjectReader() => new SyncHistoryRemovePostShowSeasonObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryRemovePostShowSeason> CreateObjectWriter() => new SyncHistoryRemovePostShowSeasonObjectJsonWriter();
    }
}
