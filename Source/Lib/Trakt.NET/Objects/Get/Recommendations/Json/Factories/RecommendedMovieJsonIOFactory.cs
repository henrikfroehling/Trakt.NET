namespace TraktNet.Objects.Get.Recommendations.Json.Factories
{
    using Get.Recommendations.Json.Reader;
    using Get.Recommendations.Json.Writer;
    using Objects.Json;

    internal class RecommendedMovieJsonIOFactory : IJsonIOFactory<ITraktRecommendedMovie>
    {
        public IObjectJsonReader<ITraktRecommendedMovie> CreateObjectReader() => new RecommendedMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktRecommendedMovie> CreateObjectWriter() => new RecommendedMovieObjectJsonWriter();
    }
}
