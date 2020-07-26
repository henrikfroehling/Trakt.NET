namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostShowEpisode>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostShowEpisode> CreateObjectReader() => new SyncRatingsPostShowEpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostShowEpisode> CreateObjectWriter() => new SyncRatingsPostShowEpisodeObjectJsonWriter();
    }
}
