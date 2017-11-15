namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Objects.Json;

    internal class EpisodeJsonReaderFactory : IJsonReaderFactory<ITraktEpisode>
    {
        public IObjectJsonReader<ITraktEpisode> CreateObjectReader() => new EpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktEpisode> CreateArrayReader() => new EpisodeArrayJsonReader();
    }
}
