namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Objects.Json;
    using System;

    internal class EpisodeIdsJsonReaderFactory : IJsonIOFactory<ITraktEpisodeIds>
    {
        public IObjectJsonReader<ITraktEpisodeIds> CreateObjectReader() => new EpisodeIdsObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeIds)} is not supported.");
        }

        public IObjectJsonReader<ITraktEpisodeIds> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktEpisodeIds> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
