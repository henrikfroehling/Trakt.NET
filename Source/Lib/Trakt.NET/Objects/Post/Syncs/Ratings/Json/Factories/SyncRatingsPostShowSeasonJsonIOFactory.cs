namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostShowSeason>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostShowSeason> CreateObjectReader() => new SyncRatingsPostShowSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostShowSeason> CreateArrayReader() => new SyncRatingsPostShowSeasonArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostShowSeason> CreateObjectWriter() => new SyncRatingsPostShowSeasonObjectJsonWriter();
    }
}
