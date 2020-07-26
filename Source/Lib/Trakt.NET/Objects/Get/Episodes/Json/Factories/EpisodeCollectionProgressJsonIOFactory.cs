namespace TraktNet.Objects.Get.Episodes.Json.Factories
{
    using Get.Episodes.Json.Reader;
    using Get.Episodes.Json.Writer;
    using Objects.Json;

    internal class EpisodeCollectionProgressJsonIOFactory : IJsonIOFactory<ITraktEpisodeCollectionProgress>
    {
        public IObjectJsonReader<ITraktEpisodeCollectionProgress> CreateObjectReader() => new EpisodeCollectionProgressObjectJsonReader();

        public IObjectJsonWriter<ITraktEpisodeCollectionProgress> CreateObjectWriter() => new EpisodeCollectionProgressObjectJsonWriter();
    }
}
