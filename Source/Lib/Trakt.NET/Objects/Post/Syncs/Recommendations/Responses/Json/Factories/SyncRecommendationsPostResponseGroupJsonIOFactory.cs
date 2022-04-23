namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRecommendationsPostResponseGroupJsonIOFactory : IJsonIOFactory<ITraktSyncRecommendationsPostResponseGroup>
    {
        public IObjectJsonReader<ITraktSyncRecommendationsPostResponseGroup> CreateObjectReader() => new SyncRecommendationsPostResponseGroupObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRecommendationsPostResponseGroup> CreateObjectWriter() => new SyncRecommendationsPostResponseGroupObjectJsonWriter();
    }
}
