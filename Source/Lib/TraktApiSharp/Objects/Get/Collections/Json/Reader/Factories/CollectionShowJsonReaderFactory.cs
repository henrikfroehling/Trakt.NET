namespace TraktApiSharp.Objects.Get.Collections.Json.Factories.Reader
{
    using Get.Collections.Json.Reader;
    using Objects.Json;

    internal class CollectionShowJsonReaderFactory : IJsonReaderFactory<ITraktCollectionShow>
    {
        public IObjectJsonReader<ITraktCollectionShow> CreateObjectReader() => new CollectionShowObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionShow> CreateArrayReader() => new CollectionShowArrayJsonReader();
    }
}
