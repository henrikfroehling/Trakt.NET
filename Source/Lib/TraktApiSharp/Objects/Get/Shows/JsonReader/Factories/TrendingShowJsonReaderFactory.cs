namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TrendingShowJsonReaderFactory : IJsonReaderFactory<ITraktTrendingShow>
    {
        public IObjectJsonReader<ITraktTrendingShow> CreateObjectReader() => new TrendingShowObjectJsonReader();

        public IArrayJsonReader<ITraktTrendingShow> CreateArrayReader() => new TrendingShowArrayJsonReader();
    }
}
