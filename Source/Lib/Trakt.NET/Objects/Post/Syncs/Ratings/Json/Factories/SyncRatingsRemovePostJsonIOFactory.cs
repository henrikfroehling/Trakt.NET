namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsRemovePostJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsRemovePost>
    {
        public IObjectJsonReader<ITraktSyncRatingsRemovePost> CreateObjectReader() => new SyncRatingsRemovePostObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsRemovePost> CreateObjectWriter() => new SyncRatingsRemovePostObjectJsonWriter();
    }
}
