namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;

    internal class SyncRatingsPostResponseNotFoundEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundEpisode>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateObjectReader() => new SyncRatingsPostResponseNotFoundEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateArrayReader() => new SyncRatingsPostResponseNotFoundEpisodeArrayJsonReader();
    }
}
