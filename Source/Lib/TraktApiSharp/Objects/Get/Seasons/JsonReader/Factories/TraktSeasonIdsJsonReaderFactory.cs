namespace TraktApiSharp.Objects.Get.Seasons.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSeasonIdsJsonReaderFactory : IJsonReaderFactory<ITraktSeasonIds>
    {
        public ITraktObjectJsonReader<ITraktSeasonIds> CreateObjectReader() => new TraktSeasonIdsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSeasonIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSeasonIds)} is not supported.");
        }
    }
}
