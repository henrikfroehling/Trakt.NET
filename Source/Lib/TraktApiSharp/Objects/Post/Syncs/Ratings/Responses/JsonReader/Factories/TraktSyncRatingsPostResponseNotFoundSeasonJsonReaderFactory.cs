namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSyncRatingsPostResponseNotFoundSeasonJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundSeason>
    {
        public ITraktObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateObjectReader() => new TraktSyncRatingsPostResponseNotFoundSeasonObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateArrayReader() => new TraktSyncRatingsPostResponseNotFoundSeasonArrayJsonReader();
    }
}
