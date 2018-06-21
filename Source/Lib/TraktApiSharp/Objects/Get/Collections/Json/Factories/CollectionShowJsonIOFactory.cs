namespace TraktNet.Objects.Get.Collections.Json.Factories
{
    using Get.Collections.Json.Reader;
    using Get.Collections.Json.Writer;
    using Objects.Json;

    internal class CollectionShowJsonIOFactory : IJsonIOFactory<ITraktCollectionShow>
    {
        public IObjectJsonReader<ITraktCollectionShow> CreateObjectReader() => new CollectionShowObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionShow> CreateArrayReader() => new CollectionShowArrayJsonReader();

        public IObjectJsonWriter<ITraktCollectionShow> CreateObjectWriter() => new CollectionShowObjectJsonWriter();
    }
}
