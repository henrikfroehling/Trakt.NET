namespace TraktNet.Objects.Post.Syncs.Recommendations.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRecommendationsPostMovieJsonIOFactory : IJsonIOFactory<ITraktSyncRecommendationsPostMovie>
    {
        public IObjectJsonReader<ITraktSyncRecommendationsPostMovie> CreateObjectReader() => new SyncRecommendationsPostMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRecommendationsPostMovie> CreateObjectWriter() => new SyncRecommendationsPostMovieObjectJsonWriter();
    }
}
