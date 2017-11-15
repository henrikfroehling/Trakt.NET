namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Objects.Json;

    internal class EpisodeTranslationJsonReaderFactory : IJsonReaderFactory<ITraktEpisodeTranslation>
    {
        public IObjectJsonReader<ITraktEpisodeTranslation> CreateObjectReader() => new EpisodeTranslationObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeTranslation> CreateArrayReader() => new EpisodeTranslationArrayJsonReader();
    }
}
