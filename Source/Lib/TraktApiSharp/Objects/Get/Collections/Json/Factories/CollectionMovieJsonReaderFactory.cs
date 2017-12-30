namespace TraktApiSharp.Objects.Get.Collections.Json.Factories
{
    using Get.Collections.Json.Reader;
    using Objects.Json;

    internal class CollectionMovieJsonReaderFactory : IJsonIOFactory<ITraktCollectionMovie>
    {
        public IObjectJsonReader<ITraktCollectionMovie> CreateObjectReader() => new CollectionMovieObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionMovie> CreateArrayReader() => new CollectionMovieArrayJsonReader();

        public IObjectJsonReader<ITraktCollectionMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktCollectionMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
