namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories.Reader
{
    using Get.Seasons.Json.Reader;
    using Objects.Json;
    using System;

    internal class SeasonIdsJsonReaderFactory : IJsonReaderFactory<ITraktSeasonIds>
    {
        public IObjectJsonReader<ITraktSeasonIds> CreateObjectReader() => new SeasonIdsObjectJsonReader();

        public IArrayJsonReader<ITraktSeasonIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSeasonIds)} is not supported.");
        }
    }
}
