namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class TrendingShowJsonIOFactory : IJsonIOFactory<ITraktTrendingShow>
    {
        public IObjectJsonReader<ITraktTrendingShow> CreateObjectReader() => new TrendingShowObjectJsonReader();

        public IArrayJsonReader<ITraktTrendingShow> CreateArrayReader() => new TrendingShowArrayJsonReader();

        public IObjectJsonWriter<ITraktTrendingShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktTrendingShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
