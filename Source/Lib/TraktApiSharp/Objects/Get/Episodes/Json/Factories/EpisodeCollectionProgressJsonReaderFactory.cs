namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Objects.Json;

    internal class EpisodeCollectionProgressJsonReaderFactory : IJsonIOFactory<ITraktEpisodeCollectionProgress>
    {
        public IObjectJsonReader<ITraktEpisodeCollectionProgress> CreateObjectReader() => new EpisodeCollectionProgressObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeCollectionProgress> CreateArrayReader() => new EpisodeCollectionProgressArrayJsonReader();

        public IObjectJsonReader<ITraktEpisodeCollectionProgress> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktEpisodeCollectionProgress> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
