namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Objects.Json;

    internal class EpisodeWatchedProgressJsonIOFactory : IJsonIOFactory<ITraktEpisodeWatchedProgress>
    {
        public IObjectJsonReader<ITraktEpisodeWatchedProgress> CreateObjectReader() => new EpisodeWatchedProgressObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeWatchedProgress> CreateArrayReader() => new EpisodeWatchedProgressArrayJsonReader();

        public IObjectJsonWriter<ITraktEpisodeWatchedProgress> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktEpisodeWatchedProgress> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
