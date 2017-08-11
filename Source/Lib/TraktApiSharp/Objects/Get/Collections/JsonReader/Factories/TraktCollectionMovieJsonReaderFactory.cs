namespace TraktApiSharp.Objects.Get.Collections.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktCollectionMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktCollectionMovie>
    {
        public ITraktObjectJsonReader<ITraktCollectionMovie> CreateObjectReader() => new TraktCollectionMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCollectionMovie> CreateArrayReader() => new TraktCollectionMovieArrayJsonReader();
    }
}
