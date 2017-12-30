namespace TraktApiSharp.Objects.Get.Watched.Json.Factories
{
    using Get.Watched.Json.Reader;
    using Objects.Json;

    internal class WatchedShowEpisodeJsonReaderFactory : IJsonIOFactory<ITraktWatchedShowEpisode>
    {
        public IObjectJsonReader<ITraktWatchedShowEpisode> CreateObjectReader() => new WatchedShowEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShowEpisode> CreateArrayReader() => new WatchedShowEpisodeArrayJsonReader();

        public IObjectJsonReader<ITraktWatchedShowEpisode> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktWatchedShowEpisode> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
