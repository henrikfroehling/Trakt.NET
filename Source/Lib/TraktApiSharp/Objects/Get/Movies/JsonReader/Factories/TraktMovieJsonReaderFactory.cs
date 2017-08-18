namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktMovieJsonReaderFactory : IJsonReaderFactory<ITraktMovie>
    {
        public ITraktObjectJsonReader<ITraktMovie> CreateObjectReader() => new TraktMovieObjectJsonReader();

        public IArrayJsonReader<ITraktMovie> CreateArrayReader() => new TraktMovieArrayJsonReader();
    }
}
