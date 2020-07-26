namespace TraktNet.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Get.Episodes.Json.Writer;
    using Objects.Json;

    internal class EpisodeJsonIOFactory : IJsonIOFactory<ITraktEpisode>
    {
        public IObjectJsonReader<ITraktEpisode> CreateObjectReader() => new EpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktEpisode> CreateObjectWriter() => new EpisodeObjectJsonWriter();
    }
}
