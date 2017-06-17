namespace TraktApiSharp.Objects.Get.Episodes.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktEpisodeWatchedProgressJsonReaderFactory : ITraktJsonReaderFactory<ITraktEpisodeWatchedProgress>
    {
        public ITraktObjectJsonReader<ITraktEpisodeWatchedProgress> CreateObjectReader() => new TraktEpisodeWatchedProgressObjectJsonReader();

        public ITraktArrayJsonReader<ITraktEpisodeWatchedProgress> CreateArrayReader() => new TraktEpisodeWatchedProgressArrayJsonReader();
    }
}
