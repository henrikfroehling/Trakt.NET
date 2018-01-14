namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Get.Episodes.Json.Writer;
    using Objects.Json;

    internal class EpisodeJsonIOFactory : IJsonIOFactory<ITraktEpisode>
    {
        public IObjectJsonReader<ITraktEpisode> CreateObjectReader() => new EpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktEpisode> CreateArrayReader() => new EpisodeArrayJsonReader();

        public IObjectJsonWriter<ITraktEpisode> CreateObjectWriter() => new EpisodeObjectJsonWriter();

        public IArrayJsonWriter<ITraktEpisode> CreateArrayWriter() => new EpisodeArrayJsonWriter();
    }
}
