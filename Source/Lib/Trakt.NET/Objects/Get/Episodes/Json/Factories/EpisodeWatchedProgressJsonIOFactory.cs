namespace TraktNet.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Get.Episodes.Json.Writer;
    using Objects.Json;

    internal class EpisodeWatchedProgressJsonIOFactory : IJsonIOFactory<ITraktEpisodeWatchedProgress>
    {
        public IObjectJsonReader<ITraktEpisodeWatchedProgress> CreateObjectReader() => new EpisodeWatchedProgressObjectJsonReader();

        public IObjectJsonWriter<ITraktEpisodeWatchedProgress> CreateObjectWriter() => new EpisodeWatchedProgressObjectJsonWriter();
    }
}
