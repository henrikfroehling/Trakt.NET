namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Objects.Json;

    internal class EpisodeJsonIOFactory : IJsonIOFactory<ITraktEpisode>
    {
        public IObjectJsonReader<ITraktEpisode> CreateObjectReader() => new EpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktEpisode> CreateArrayReader() => new EpisodeArrayJsonReader();

        public IObjectJsonWriter<ITraktEpisode> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktEpisode> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
