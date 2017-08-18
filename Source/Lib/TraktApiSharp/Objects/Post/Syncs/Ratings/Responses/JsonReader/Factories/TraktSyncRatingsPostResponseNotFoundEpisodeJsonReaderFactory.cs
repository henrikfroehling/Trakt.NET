namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSyncRatingsPostResponseNotFoundEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundEpisode>
    {
        public ITraktObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateObjectReader() => new TraktSyncRatingsPostResponseNotFoundEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateArrayReader() => new TraktSyncRatingsPostResponseNotFoundEpisodeArrayJsonReader();
    }
}
