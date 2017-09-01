namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class BoxOfficeMovieJsonReaderFactory : IJsonReaderFactory<ITraktBoxOfficeMovie>
    {
        public IObjectJsonReader<ITraktBoxOfficeMovie> CreateObjectReader() => new TraktBoxOfficeMovieObjectJsonReader();

        public IArrayJsonReader<ITraktBoxOfficeMovie> CreateArrayReader() => new BoxOfficeMovieArrayJsonReader();
    }
}
