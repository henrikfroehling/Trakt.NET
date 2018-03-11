namespace TraktApiSharp.Objects.Get.Collections.Json.Factories
{
    using Get.Collections.Json.Reader;
    using Get.Collections.Json.Writer;
    using Objects.Json;

    internal class CollectionMovieJsonIOFactory : IJsonIOFactory<ITraktCollectionMovie>
    {
        public IObjectJsonReader<ITraktCollectionMovie> CreateObjectReader() => new CollectionMovieObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionMovie> CreateArrayReader() => new CollectionMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktCollectionMovie> CreateObjectWriter() => new CollectionMovieObjectJsonWriter();
    }
}
