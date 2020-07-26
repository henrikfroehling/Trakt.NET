namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostResponseNotFoundEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundEpisode>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateObjectReader()
            => new SyncRatingsPostResponseNotFoundEpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateObjectWriter()
            => new SyncRatingsPostResponseNotFoundEpisodeObjectJsonWriter();
    }
}
