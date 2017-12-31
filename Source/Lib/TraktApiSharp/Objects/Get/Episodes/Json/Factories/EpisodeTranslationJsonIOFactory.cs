namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Objects.Json;

    internal class EpisodeTranslationJsonIOFactory : IJsonIOFactory<ITraktEpisodeTranslation>
    {
        public IObjectJsonReader<ITraktEpisodeTranslation> CreateObjectReader() => new EpisodeTranslationObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeTranslation> CreateArrayReader() => new EpisodeTranslationArrayJsonReader();

        public IObjectJsonWriter<ITraktEpisodeTranslation> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktEpisodeTranslation> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
