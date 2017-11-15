namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Objects.Json;

    internal class BoxOfficeMovieJsonReaderFactory : IJsonReaderFactory<ITraktBoxOfficeMovie>
    {
        public IObjectJsonReader<ITraktBoxOfficeMovie> CreateObjectReader() => new BoxOfficeMovieObjectJsonReader();

        public IArrayJsonReader<ITraktBoxOfficeMovie> CreateArrayReader() => new BoxOfficeMovieArrayJsonReader();
    }
}
