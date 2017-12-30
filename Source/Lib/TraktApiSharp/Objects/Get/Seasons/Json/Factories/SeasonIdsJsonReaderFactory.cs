namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories
{
    using Get.Seasons.Json.Reader;
    using Objects.Json;
    using System;

    internal class SeasonIdsJsonReaderFactory : IJsonIOFactory<ITraktSeasonIds>
    {
        public IObjectJsonReader<ITraktSeasonIds> CreateObjectReader() => new SeasonIdsObjectJsonReader();

        public IArrayJsonReader<ITraktSeasonIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSeasonIds)} is not supported.");
        }

        public IObjectJsonReader<ITraktSeasonIds> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSeasonIds> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
