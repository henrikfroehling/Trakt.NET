namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Objects.Json;

    internal class EpisodeWatchedProgressJsonReaderFactory : IJsonReaderFactory<ITraktEpisodeWatchedProgress>
    {
        public IObjectJsonReader<ITraktEpisodeWatchedProgress> CreateObjectReader() => new EpisodeWatchedProgressObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeWatchedProgress> CreateArrayReader() => new EpisodeWatchedProgressArrayJsonReader();
    }
}
