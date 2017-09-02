namespace TraktApiSharp.Objects.Get.Watched.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class WatchedShowEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktWatchedShowEpisode>
    {
        public IObjectJsonReader<ITraktWatchedShowEpisode> CreateObjectReader() => new WatchedShowEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShowEpisode> CreateArrayReader() => new WatchedShowEpisodeArrayJsonReader();
    }
}
