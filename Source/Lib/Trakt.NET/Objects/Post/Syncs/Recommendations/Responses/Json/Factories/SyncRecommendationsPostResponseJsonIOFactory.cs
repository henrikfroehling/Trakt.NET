namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRecommendationsPostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncRecommendationsPostResponse>
    {
        public IObjectJsonReader<ITraktSyncRecommendationsPostResponse> CreateObjectReader() => new SyncRecommendationsPostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRecommendationsPostResponse> CreateObjectWriter() => new SyncRecommendationsPostResponseObjectJsonWriter();
    }
}
