namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class SyncRatingsPostResponseNotFoundSeasonJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundSeason>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateObjectReader() => new TraktSyncRatingsPostResponseNotFoundSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateArrayReader() => new SyncRatingsPostResponseNotFoundSeasonArrayJsonReader();
    }
}
