namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Syncs.History.Json.Reader;
    using TraktNet.Objects.Post.Syncs.History.Json.Writer;

    internal class SyncHistoryRemovePostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostShowEpisode>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostShowEpisode> CreateObjectReader() => new SyncHistoryRemovePostShowEpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryRemovePostShowEpisode> CreateObjectWriter() => new SyncHistoryRemovePostShowEpisodeObjectJsonWriter();
    }
}
