namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktTrendingShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktTrendingShow>
    {
        public ITraktObjectJsonReader<ITraktTrendingShow> CreateObjectReader() => new TraktTrendingShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktTrendingShow> CreateArrayReader() => new TraktTrendingShowArrayJsonReader();
    }
}
