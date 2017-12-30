namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;

    internal class SyncRatingsPostResponseNotFoundSeasonJsonReaderFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundSeason>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateObjectReader() => new SyncRatingsPostResponseNotFoundSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateArrayReader() => new SyncRatingsPostResponseNotFoundSeasonArrayJsonReader();

        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
