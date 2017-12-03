namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;

    internal class SyncRatingsPostResponseNotFoundEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundEpisode>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateObjectReader() => new SyncRatingsPostResponseNotFoundEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateArrayReader() => new SyncRatingsPostResponseNotFoundEpisodeArrayJsonReader();
    }
}
