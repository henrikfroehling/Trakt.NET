namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSyncRatingsPostResponseNotFoundEpisodeJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundEpisode>
    {
        public ITraktObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateObjectReader() => new TraktSyncRatingsPostResponseNotFoundEpisodeObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateArrayReader() => new TraktSyncRatingsPostResponseNotFoundEpisodeArrayJsonReader();
    }
}
