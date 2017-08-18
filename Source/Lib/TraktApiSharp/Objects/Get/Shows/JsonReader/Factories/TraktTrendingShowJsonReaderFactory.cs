namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktTrendingShowJsonReaderFactory : IJsonReaderFactory<ITraktTrendingShow>
    {
        public ITraktObjectJsonReader<ITraktTrendingShow> CreateObjectReader() => new TraktTrendingShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktTrendingShow> CreateArrayReader() => new TraktTrendingShowArrayJsonReader();
    }
}
