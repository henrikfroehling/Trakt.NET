namespace TraktNet.Objects.Get.Recommendations.Json.Factories
{
    using Get.Recommendations.Json.Reader;
    using Get.Recommendations.Json.Writer;
    using Objects.Json;

    internal class RecommendedByJsonIOFactory : IJsonIOFactory<ITraktRecommendedBy>
    {
        public IObjectJsonReader<ITraktRecommendedBy> CreateObjectReader() => new RecommendedByObjectJsonReader();

        public IObjectJsonWriter<ITraktRecommendedBy> CreateObjectWriter() => new RecommendedByObjectJsonWriter();
    }
}
