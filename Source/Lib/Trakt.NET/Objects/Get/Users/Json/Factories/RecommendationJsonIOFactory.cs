namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class RecommendationJsonIOFactory : IJsonIOFactory<ITraktRecommendation>
    {
        public IObjectJsonReader<ITraktRecommendation> CreateObjectReader() => new RecommendationObjectJsonReader();

        public IObjectJsonWriter<ITraktRecommendation> CreateObjectWriter() => new RecommendationObjectJsonWriter();
    }
}
