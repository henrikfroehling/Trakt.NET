namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Syncs.History.Json.Reader;
    using TraktNet.Objects.Post.Syncs.History.Json.Writer;

    internal class SyncHistoryRemovePostSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostSeason>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostSeason> CreateObjectReader() => new SyncHistoryRemovePostSeasonObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryRemovePostSeason> CreateObjectWriter() => new SyncHistoryRemovePostSeasonObjectJsonWriter();
    }
}
