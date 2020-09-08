namespace TraktNet.Objects.Get.Recommendations.Json.Factories
{
    using Get.Recommendations.Json.Reader;
    using Get.Recommendations.Json.Writer;
    using Objects.Json;

    internal class RecommendationShowJsonIOFactory : IJsonIOFactory<ITraktRecommendationShow>
    {
        public IObjectJsonReader<ITraktRecommendationShow> CreateObjectReader() => new RecommendationShowObjectJsonReader();

        public IObjectJsonWriter<ITraktRecommendationShow> CreateObjectWriter() => new RecommendationShowObjectJsonWriter();
    }
}
