namespace TraktNet.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Get.Episodes.Json.Writer;
    using Objects.Json;

    internal class EpisodeTranslationJsonIOFactory : IJsonIOFactory<ITraktEpisodeTranslation>
    {
        public IObjectJsonReader<ITraktEpisodeTranslation> CreateObjectReader() => new EpisodeTranslationObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeTranslation> CreateArrayReader() => new EpisodeTranslationArrayJsonReader();

        public IObjectJsonWriter<ITraktEpisodeTranslation> CreateObjectWriter() => new EpisodeTranslationObjectJsonWriter();
    }
}
