namespace TraktApiSharp.Objects.Get.Collections.Json.Factories
{
    using Objects.Json;

    internal class CollectionShowEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktCollectionShowEpisode>
    {
        public IObjectJsonReader<ITraktCollectionShowEpisode> CreateObjectReader() => new CollectionShowEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionShowEpisode> CreateArrayReader() => new CollectionShowEpisodeArrayJsonReader();
    }
}
