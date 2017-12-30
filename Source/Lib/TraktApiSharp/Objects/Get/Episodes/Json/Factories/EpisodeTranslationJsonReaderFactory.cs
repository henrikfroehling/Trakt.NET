namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Objects.Json;

    internal class EpisodeTranslationJsonReaderFactory : IJsonIOFactory<ITraktEpisodeTranslation>
    {
        public IObjectJsonReader<ITraktEpisodeTranslation> CreateObjectReader() => new EpisodeTranslationObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeTranslation> CreateArrayReader() => new EpisodeTranslationArrayJsonReader();

        public IObjectJsonReader<ITraktEpisodeTranslation> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktEpisodeTranslation> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
