namespace TraktApiSharp.Objects.Get.Episodes.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktEpisodeTranslationJsonReaderFactory : IJsonReaderFactory<ITraktEpisodeTranslation>
    {
        public ITraktObjectJsonReader<ITraktEpisodeTranslation> CreateObjectReader() => new TraktEpisodeTranslationObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeTranslation> CreateArrayReader() => new TraktEpisodeTranslationArrayJsonReader();
    }
}
