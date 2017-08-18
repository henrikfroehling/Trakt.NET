namespace TraktApiSharp.Objects.Get.Collections.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktCollectionMovieJsonReaderFactory : IJsonReaderFactory<ITraktCollectionMovie>
    {
        public ITraktObjectJsonReader<ITraktCollectionMovie> CreateObjectReader() => new TraktCollectionMovieObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionMovie> CreateArrayReader() => new TraktCollectionMovieArrayJsonReader();
    }
}
