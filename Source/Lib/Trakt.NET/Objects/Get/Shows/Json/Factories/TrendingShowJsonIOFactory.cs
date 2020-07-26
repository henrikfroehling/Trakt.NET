namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class TrendingShowJsonIOFactory : IJsonIOFactory<ITraktTrendingShow>
    {
        public IObjectJsonReader<ITraktTrendingShow> CreateObjectReader() => new TrendingShowObjectJsonReader();

        public IObjectJsonWriter<ITraktTrendingShow> CreateObjectWriter() => new TrendingShowObjectJsonWriter();
    }
}
