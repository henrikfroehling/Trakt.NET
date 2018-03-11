namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostResponseNotFoundSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundSeason>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateObjectReader()
            => new SyncRatingsPostResponseNotFoundSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateArrayReader()
            => new SyncRatingsPostResponseNotFoundSeasonArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostResponseNotFoundSeason> CreateObjectWriter()
            => new SyncRatingsPostResponseNotFoundSeasonObjectJsonWriter();
    }
}
