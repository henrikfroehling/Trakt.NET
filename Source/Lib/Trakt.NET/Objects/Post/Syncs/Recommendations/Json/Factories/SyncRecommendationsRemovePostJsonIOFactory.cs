namespace TraktNet.Objects.Post.Syncs.Recommendations.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRecommendationsRemovePostJsonIOFactory : IJsonIOFactory<ITraktSyncRecommendationsRemovePost>
    {
        public IObjectJsonReader<ITraktSyncRecommendationsRemovePost> CreateObjectReader() => new SyncRecommendationsRemovePostObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRecommendationsRemovePost> CreateObjectWriter() => new SyncRecommendationsRemovePostObjectJsonWriter();
    }
}
