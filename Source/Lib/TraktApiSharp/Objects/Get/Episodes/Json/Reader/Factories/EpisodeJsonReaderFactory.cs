namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories.Reader
{
    using Get.Episodes.Json.Reader;
    using Objects.Json;

    internal class EpisodeJsonReaderFactory : IJsonReaderFactory<ITraktEpisode>
    {
        public IObjectJsonReader<ITraktEpisode> CreateObjectReader() => new EpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktEpisode> CreateArrayReader() => new EpisodeArrayJsonReader();
    }
}
