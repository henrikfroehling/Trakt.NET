namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Objects.Json;

    internal class EpisodeJsonReaderFactory : IJsonIOFactory<ITraktEpisode>
    {
        public IObjectJsonReader<ITraktEpisode> CreateObjectReader() => new EpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktEpisode> CreateArrayReader() => new EpisodeArrayJsonReader();

        public IObjectJsonReader<ITraktEpisode> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktEpisode> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
