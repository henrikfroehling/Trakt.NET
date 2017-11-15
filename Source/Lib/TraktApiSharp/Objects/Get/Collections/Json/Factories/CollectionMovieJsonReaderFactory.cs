namespace TraktApiSharp.Objects.Get.Collections.Json.Factories
{
    using Objects.Json;

    internal class CollectionMovieJsonReaderFactory : IJsonReaderFactory<ITraktCollectionMovie>
    {
        public IObjectJsonReader<ITraktCollectionMovie> CreateObjectReader() => new CollectionMovieObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionMovie> CreateArrayReader() => new CollectionMovieArrayJsonReader();
    }
}
