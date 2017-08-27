namespace TraktApiSharp.Objects.Get.Collections.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class CollectionShowJsonReaderFactory : IJsonReaderFactory<ITraktCollectionShow>
    {
        public IObjectJsonReader<ITraktCollectionShow> CreateObjectReader() => new TraktCollectionShowObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionShow> CreateArrayReader() => new TraktCollectionShowArrayJsonReader();
    }
}
