namespace TraktApiSharp.Objects.Get.Collections.Json.Factories
{
    using Get.Collections.Json.Reader;
    using Objects.Json;

    internal class CollectionShowJsonReaderFactory : IJsonIOFactory<ITraktCollectionShow>
    {
        public IObjectJsonReader<ITraktCollectionShow> CreateObjectReader() => new CollectionShowObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionShow> CreateArrayReader() => new CollectionShowArrayJsonReader();

        public IObjectJsonReader<ITraktCollectionShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktCollectionShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
