namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Objects.Json;

    internal class EpisodeWatchedProgressJsonReaderFactory : IJsonIOFactory<ITraktEpisodeWatchedProgress>
    {
        public IObjectJsonReader<ITraktEpisodeWatchedProgress> CreateObjectReader() => new EpisodeWatchedProgressObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeWatchedProgress> CreateArrayReader() => new EpisodeWatchedProgressArrayJsonReader();

        public IObjectJsonReader<ITraktEpisodeWatchedProgress> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktEpisodeWatchedProgress> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
