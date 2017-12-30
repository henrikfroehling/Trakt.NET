namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class TrendingShowJsonReaderFactory : IJsonIOFactory<ITraktTrendingShow>
    {
        public IObjectJsonReader<ITraktTrendingShow> CreateObjectReader() => new TrendingShowObjectJsonReader();

        public IArrayJsonReader<ITraktTrendingShow> CreateArrayReader() => new TrendingShowArrayJsonReader();

        public IObjectJsonReader<ITraktTrendingShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktTrendingShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
