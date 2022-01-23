namespace TraktNet.Objects.Post.Syncs.Recommendations.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRecommendationsPostJsonIOFactory : IJsonIOFactory<ITraktSyncRecommendationsPost>
    {
        public IObjectJsonReader<ITraktSyncRecommendationsPost> CreateObjectReader() => new SyncRecommendationsPostObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRecommendationsPost> CreateObjectWriter() => new SyncRecommendationsPostObjectJsonWriter();
    }
}
