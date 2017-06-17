namespace TraktApiSharp.Objects.Get.Episodes.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktEpisodeIdsJsonReaderFactory : ITraktJsonReaderFactory<ITraktEpisodeIds>
    {
        public ITraktObjectJsonReader<ITraktEpisodeIds> CreateObjectReader() => new TraktEpisodeIdsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktEpisodeIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeIds)} is not supported.");
        }
    }
}
