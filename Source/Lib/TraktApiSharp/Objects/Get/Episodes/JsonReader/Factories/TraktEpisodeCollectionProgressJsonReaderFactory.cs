namespace TraktApiSharp.Objects.Get.Episodes.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktEpisodeCollectionProgressJsonReaderFactory : IJsonReaderFactory<ITraktEpisodeCollectionProgress>
    {
        public ITraktObjectJsonReader<ITraktEpisodeCollectionProgress> CreateObjectReader() => new TraktEpisodeCollectionProgressObjectJsonReader();

        public ITraktArrayJsonReader<ITraktEpisodeCollectionProgress> CreateArrayReader() => new TraktEpisodeCollectionProgressArrayJsonReader();
    }
}
