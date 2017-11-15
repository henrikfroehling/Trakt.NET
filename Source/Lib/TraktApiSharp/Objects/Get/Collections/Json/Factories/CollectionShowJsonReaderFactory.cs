namespace TraktApiSharp.Objects.Get.Collections.Json.Factories
{
    using Objects.Json;

    internal class CollectionShowJsonReaderFactory : IJsonReaderFactory<ITraktCollectionShow>
    {
        public IObjectJsonReader<ITraktCollectionShow> CreateObjectReader() => new CollectionShowObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionShow> CreateArrayReader() => new CollectionShowArrayJsonReader();
    }
}
