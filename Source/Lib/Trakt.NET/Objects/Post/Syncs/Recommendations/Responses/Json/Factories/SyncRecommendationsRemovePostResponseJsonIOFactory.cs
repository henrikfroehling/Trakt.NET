namespace TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRecommendationsRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncRecommendationsRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncRecommendationsRemovePostResponse> CreateObjectReader() => new SyncRecommendationsRemovePostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRecommendationsRemovePostResponse> CreateObjectWriter() => new SyncRecommendationsRemovePostResponseObjectJsonWriter();
    }
}
