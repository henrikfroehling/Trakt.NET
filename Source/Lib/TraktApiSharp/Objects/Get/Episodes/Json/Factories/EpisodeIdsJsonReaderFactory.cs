namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Objects.Json;
    using System;

    internal class EpisodeIdsJsonReaderFactory : IJsonReaderFactory<ITraktEpisodeIds>
    {
        public IObjectJsonReader<ITraktEpisodeIds> CreateObjectReader() => new EpisodeIdsObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeIds)} is not supported.");
        }
    }
}
