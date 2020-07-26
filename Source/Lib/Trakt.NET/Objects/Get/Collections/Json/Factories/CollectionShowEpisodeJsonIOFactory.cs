namespace TraktNet.Objects.Get.Collections.Json.Factories
{
    using Get.Collections.Json.Reader;
    using Get.Collections.Json.Writer;
    using Objects.Json;

    internal class CollectionShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktCollectionShowEpisode>
    {
        public IObjectJsonReader<ITraktCollectionShowEpisode> CreateObjectReader() => new CollectionShowEpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktCollectionShowEpisode> CreateObjectWriter() => new CollectionShowEpisodeObjectJsonWriter();
    }
}
