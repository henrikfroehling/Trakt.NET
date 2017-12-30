namespace TraktApiSharp.Objects.Get.Collections.Json.Factories
{
    using Get.Collections.Json.Reader;
    using Objects.Json;

    internal class CollectionShowEpisodeJsonReaderFactory : IJsonIOFactory<ITraktCollectionShowEpisode>
    {
        public IObjectJsonReader<ITraktCollectionShowEpisode> CreateObjectReader() => new CollectionShowEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionShowEpisode> CreateArrayReader() => new CollectionShowEpisodeArrayJsonReader();

        public IObjectJsonReader<ITraktCollectionShowEpisode> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktCollectionShowEpisode> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
