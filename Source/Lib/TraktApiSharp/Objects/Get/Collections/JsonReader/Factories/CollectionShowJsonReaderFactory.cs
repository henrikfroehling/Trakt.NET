namespace TraktApiSharp.Objects.Get.Collections.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class CollectionShowJsonReaderFactory : IJsonReaderFactory<ITraktCollectionShow>
    {
        public IObjectJsonReader<ITraktCollectionShow> CreateObjectReader() => new CollectionShowObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionShow> CreateArrayReader() => new CollectionShowArrayJsonReader();
    }
}
