namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class MostRecommendedShowJsonIOFactory : IJsonIOFactory<ITraktMostRecommendedShow>
    {
        public IObjectJsonReader<ITraktMostRecommendedShow> CreateObjectReader() => new MostRecommendedShowObjectJsonReader();

        public IObjectJsonWriter<ITraktMostRecommendedShow> CreateObjectWriter() => new MostRecommendedShowObjectJsonWriter();
    }
}
