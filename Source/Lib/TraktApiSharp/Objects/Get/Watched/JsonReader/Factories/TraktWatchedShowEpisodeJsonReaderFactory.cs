namespace TraktApiSharp.Objects.Get.Watched.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktWatchedShowEpisodeJsonReaderFactory : ITraktJsonReaderFactory<ITraktWatchedShowEpisode>
    {
        public ITraktObjectJsonReader<ITraktWatchedShowEpisode> CreateObjectReader() => new TraktWatchedShowEpisodeObjectJsonReader();

        public ITraktArrayJsonReader<ITraktWatchedShowEpisode> CreateArrayReader() => new TraktWatchedShowEpisodeArrayJsonReader();
    }
}
