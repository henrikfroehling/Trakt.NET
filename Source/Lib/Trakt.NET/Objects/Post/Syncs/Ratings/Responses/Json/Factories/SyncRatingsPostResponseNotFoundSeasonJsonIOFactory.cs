namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostResponseNotFoundSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundSeason>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundSeason> CreateObjectReader()
            => new SyncRatingsPostResponseNotFoundSeasonObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostResponseNotFoundSeason> CreateObjectWriter()
            => new SyncRatingsPostResponseNotFoundSeasonObjectJsonWriter();
    }
}
