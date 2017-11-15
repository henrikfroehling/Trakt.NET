namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;

    internal class SyncRatingsPostResponseNotFoundSeasonJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundSeason>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateObjectReader() => new SyncRatingsPostResponseNotFoundSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateArrayReader() => new SyncRatingsPostResponseNotFoundSeasonArrayJsonReader();
    }
}
