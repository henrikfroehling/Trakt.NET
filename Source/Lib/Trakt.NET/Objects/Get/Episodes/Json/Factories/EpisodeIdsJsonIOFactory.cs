namespace TraktNet.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Get.Episodes.Json.Writer;
    using Objects.Json;

    internal class EpisodeIdsJsonIOFactory : IJsonIOFactory<ITraktEpisodeIds>
    {
        public IObjectJsonReader<ITraktEpisodeIds> CreateObjectReader() => new EpisodeIdsObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeIds> CreateArrayReader() => new EpisodeIdsArrayJsonReader();

        public IObjectJsonWriter<ITraktEpisodeIds> CreateObjectWriter() => new EpisodeIdsObjectJsonWriter();
    }
}
