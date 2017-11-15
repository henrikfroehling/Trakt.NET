namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories
{
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
