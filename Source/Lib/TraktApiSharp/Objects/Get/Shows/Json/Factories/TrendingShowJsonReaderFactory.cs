namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Objects.Json;

    internal class TrendingShowJsonReaderFactory : IJsonReaderFactory<ITraktTrendingShow>
    {
        public IObjectJsonReader<ITraktTrendingShow> CreateObjectReader() => new TrendingShowObjectJsonReader();

        public IArrayJsonReader<ITraktTrendingShow> CreateArrayReader() => new TrendingShowArrayJsonReader();
    }
}
