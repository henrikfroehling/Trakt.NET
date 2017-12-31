namespace TraktApiSharp.Objects.Get.Watched.Json.Factories
{
    using Get.Watched.Json.Reader;
    using Objects.Json;

    internal class WatchedShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktWatchedShowEpisode>
    {
        public IObjectJsonReader<ITraktWatchedShowEpisode> CreateObjectReader() => new WatchedShowEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShowEpisode> CreateArrayReader() => new WatchedShowEpisodeArrayJsonReader();

        public IObjectJsonWriter<ITraktWatchedShowEpisode> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktWatchedShowEpisode> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
