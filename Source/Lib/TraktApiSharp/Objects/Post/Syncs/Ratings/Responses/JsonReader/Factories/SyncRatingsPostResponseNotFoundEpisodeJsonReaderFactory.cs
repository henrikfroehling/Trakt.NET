namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class SyncRatingsPostResponseNotFoundEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundEpisode>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateObjectReader() => new TraktSyncRatingsPostResponseNotFoundEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateArrayReader() => new TraktSyncRatingsPostResponseNotFoundEpisodeArrayJsonReader();
    }
}
