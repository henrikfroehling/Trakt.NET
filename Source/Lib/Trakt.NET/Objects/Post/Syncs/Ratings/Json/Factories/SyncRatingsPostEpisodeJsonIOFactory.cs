namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostEpisode>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostEpisode> CreateObjectReader() => new SyncRatingsPostEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostEpisode> CreateArrayReader() => new SyncRatingsPostEpisodeArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostEpisode> CreateObjectWriter() => new SyncRatingsPostEpisodeObjectJsonWriter();
    }
}
