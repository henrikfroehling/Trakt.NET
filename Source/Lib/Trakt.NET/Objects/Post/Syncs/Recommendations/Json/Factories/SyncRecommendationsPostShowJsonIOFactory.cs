namespace TraktNet.Objects.Post.Syncs.Recommendations.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRecommendationsPostShowJsonIOFactory : IJsonIOFactory<ITraktSyncRecommendationsPostShow>
    {
        public IObjectJsonReader<ITraktSyncRecommendationsPostShow> CreateObjectReader() => new SyncRecommendationsPostShowObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRecommendationsPostShow> CreateObjectWriter() => new SyncRecommendationsPostShowObjectJsonWriter();
    }
}
