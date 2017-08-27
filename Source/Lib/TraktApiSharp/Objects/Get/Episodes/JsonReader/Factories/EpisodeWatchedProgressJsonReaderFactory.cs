namespace TraktApiSharp.Objects.Get.Episodes.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class EpisodeWatchedProgressJsonReaderFactory : IJsonReaderFactory<ITraktEpisodeWatchedProgress>
    {
        public IObjectJsonReader<ITraktEpisodeWatchedProgress> CreateObjectReader() => new TraktEpisodeWatchedProgressObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeWatchedProgress> CreateArrayReader() => new EpisodeWatchedProgressArrayJsonReader();
    }
}
