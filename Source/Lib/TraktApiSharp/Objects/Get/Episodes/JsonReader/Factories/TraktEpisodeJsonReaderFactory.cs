namespace TraktApiSharp.Objects.Get.Episodes.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktEpisode>
    {
        public ITraktObjectJsonReader<ITraktEpisode> CreateObjectReader() => new TraktEpisodeObjectJsonReader();

        public ITraktArrayJsonReader<ITraktEpisode> CreateArrayReader() => new TraktEpisodeArrayJsonReader();
    }
}
