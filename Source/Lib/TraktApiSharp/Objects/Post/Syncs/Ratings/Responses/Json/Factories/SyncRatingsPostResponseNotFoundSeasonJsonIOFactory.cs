namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;

    internal class SyncRatingsPostResponseNotFoundSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundSeason>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateObjectReader() => new SyncRatingsPostResponseNotFoundSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateArrayReader() => new SyncRatingsPostResponseNotFoundSeasonArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostResponseNotFoundSeason> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncRatingsPostResponseNotFoundSeason> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
