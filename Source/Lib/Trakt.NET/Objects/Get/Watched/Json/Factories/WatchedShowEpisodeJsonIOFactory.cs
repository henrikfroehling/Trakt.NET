namespace TraktNet.Objects.Get.Watched.Json.Factories
{
    using Get.Watched.Json.Reader;
    using Get.Watched.Json.Writer;
    using Objects.Json;

    internal class WatchedShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktWatchedShowEpisode>
    {
        public IObjectJsonReader<ITraktWatchedShowEpisode> CreateObjectReader() => new WatchedShowEpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktWatchedShowEpisode> CreateObjectWriter() => new WatchedShowEpisodeObjectJsonWriter();
    }
}
