namespace TraktApiSharp.Objects.Get.Watched.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktWatchedShowEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktWatchedShowEpisode>
    {
        public ITraktObjectJsonReader<ITraktWatchedShowEpisode> CreateObjectReader() => new TraktWatchedShowEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShowEpisode> CreateArrayReader() => new TraktWatchedShowEpisodeArrayJsonReader();
    }
}
