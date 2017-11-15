namespace TraktApiSharp.Objects.Get.Episodes.Json.Factories
{
    using Objects.Json;

    internal class EpisodeCollectionProgressJsonReaderFactory : IJsonReaderFactory<ITraktEpisodeCollectionProgress>
    {
        public IObjectJsonReader<ITraktEpisodeCollectionProgress> CreateObjectReader() => new EpisodeCollectionProgressObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeCollectionProgress> CreateArrayReader() => new EpisodeCollectionProgressArrayJsonReader();
    }
}
