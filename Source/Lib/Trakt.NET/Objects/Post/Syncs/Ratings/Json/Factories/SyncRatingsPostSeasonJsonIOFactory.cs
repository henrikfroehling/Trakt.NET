namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostSeason>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostSeason> CreateObjectReader() => new SyncRatingsPostSeasonObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostSeason> CreateObjectWriter() => new SyncRatingsPostSeasonObjectJsonWriter();
    }
}
