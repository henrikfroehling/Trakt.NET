namespace TraktNet.Objects.Get.Recommendations.Json.Factories
{
    using Get.Recommendations.Json.Reader;
    using Get.Recommendations.Json.Writer;
    using Objects.Json;

    internal class RecommendedShowJsonIOFactory : IJsonIOFactory<ITraktRecommendedShow>
    {
        public IObjectJsonReader<ITraktRecommendedShow> CreateObjectReader() => new RecommendedShowObjectJsonReader();

        public IObjectJsonWriter<ITraktRecommendedShow> CreateObjectWriter() => new RecommendedShowObjectJsonWriter();
    }
}
