namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories
{
    using Get.Seasons.Json.Reader;
    using Objects.Json;
    using System;

    internal class SeasonIdsJsonIOFactory : IJsonIOFactory<ITraktSeasonIds>
    {
        public IObjectJsonReader<ITraktSeasonIds> CreateObjectReader() => new SeasonIdsObjectJsonReader();

        public IArrayJsonReader<ITraktSeasonIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSeasonIds)} is not supported.");
        }

        public IObjectJsonWriter<ITraktSeasonIds> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSeasonIds> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
