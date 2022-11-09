namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Syncs.History.Json.Reader;
    using TraktNet.Objects.Post.Syncs.History.Json.Writer;

    internal class SyncHistoryRemovePostEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostEpisode>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostEpisode> CreateObjectReader() => new SyncHistoryRemovePostEpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryRemovePostEpisode> CreateObjectWriter() => new SyncHistoryRemovePostEpisodeObjectJsonWriter();
    }
}
