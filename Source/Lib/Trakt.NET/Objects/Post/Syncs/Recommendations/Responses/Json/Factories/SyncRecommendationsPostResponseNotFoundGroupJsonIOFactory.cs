namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRecommendationsPostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktSyncRecommendationsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncRecommendationsPostResponseNotFoundGroup> CreateObjectReader() => new SyncRecommendationsPostResponseNotFoundGroupObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRecommendationsPostResponseNotFoundGroup> CreateObjectWriter() => new SyncRecommendationsPostResponseNotFoundGroupObjectJsonWriter();
    }
}
