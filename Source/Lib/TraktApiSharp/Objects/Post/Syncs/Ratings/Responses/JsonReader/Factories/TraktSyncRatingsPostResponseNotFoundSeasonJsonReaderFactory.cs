namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSyncRatingsPostResponseNotFoundSeasonJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundSeason>
    {
        public ITraktObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateObjectReader() => new TraktSyncRatingsPostResponseNotFoundSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateArrayReader() => new TraktSyncRatingsPostResponseNotFoundSeasonArrayJsonReader();
    }
}
