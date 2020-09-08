namespace TraktNet.Objects.Get.Recommendations.Json.Factories
{
    using Get.Recommendations.Json.Reader;
    using Get.Recommendations.Json.Writer;
    using Objects.Json;

    internal class RecommendationMovieJsonIOFactory : IJsonIOFactory<ITraktRecommendationMovie>
    {
        public IObjectJsonReader<ITraktRecommendationMovie> CreateObjectReader() => new RecommendationMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktRecommendationMovie> CreateObjectWriter() => new RecommendationMovieObjectJsonWriter();
    }
}
