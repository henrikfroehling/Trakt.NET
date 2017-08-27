namespace TraktApiSharp.Objects.Get.Episodes.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class EpisodeCollectionProgressJsonReaderFactory : IJsonReaderFactory<ITraktEpisodeCollectionProgress>
    {
        public IObjectJsonReader<ITraktEpisodeCollectionProgress> CreateObjectReader() => new TraktEpisodeCollectionProgressObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeCollectionProgress> CreateArrayReader() => new EpisodeCollectionProgressArrayJsonReader();
    }
}
