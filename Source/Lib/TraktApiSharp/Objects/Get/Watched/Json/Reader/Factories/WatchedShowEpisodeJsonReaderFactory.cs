namespace TraktApiSharp.Objects.Get.Watched.Json.Factories.Reader
{
    using Get.Watched.Json.Reader;
    using Objects.Json;

    internal class WatchedShowEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktWatchedShowEpisode>
    {
        public IObjectJsonReader<ITraktWatchedShowEpisode> CreateObjectReader() => new WatchedShowEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShowEpisode> CreateArrayReader() => new WatchedShowEpisodeArrayJsonReader();
    }
}
