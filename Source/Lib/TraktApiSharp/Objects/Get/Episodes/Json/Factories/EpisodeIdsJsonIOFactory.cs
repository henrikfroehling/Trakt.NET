namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Get.Episodes.Json.Writer;
    using Objects.Json;
    using System;

    internal class EpisodeIdsJsonIOFactory : IJsonIOFactory<ITraktEpisodeIds>
    {
        public IObjectJsonReader<ITraktEpisodeIds> CreateObjectReader() => new EpisodeIdsObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeIds> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeIds)} is not supported.");

        public IObjectJsonWriter<ITraktEpisodeIds> CreateObjectWriter() => new EpisodeIdsObjectJsonWriter();
    }
}
