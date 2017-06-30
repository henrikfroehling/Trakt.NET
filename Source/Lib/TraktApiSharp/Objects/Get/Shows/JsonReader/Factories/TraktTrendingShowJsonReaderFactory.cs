namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktTrendingShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktTrendingShow>
    {
        public ITraktObjectJsonReader<ITraktTrendingShow> CreateObjectReader() => new TraktTrendingShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktTrendingShow> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowWatchedProgress)} is not supported.");
        }
    }
}
