namespace TraktApiSharp.Objects.Get.Collections.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class CollectionMovieJsonReaderFactory : IJsonReaderFactory<ITraktCollectionMovie>
    {
        public IObjectJsonReader<ITraktCollectionMovie> CreateObjectReader() => new CollectionMovieObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionMovie> CreateArrayReader() => new CollectionMovieArrayJsonReader();
    }
}
