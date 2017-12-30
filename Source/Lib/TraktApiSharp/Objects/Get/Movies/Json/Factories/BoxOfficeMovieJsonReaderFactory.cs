namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class BoxOfficeMovieJsonReaderFactory : IJsonIOFactory<ITraktBoxOfficeMovie>
    {
        public IObjectJsonReader<ITraktBoxOfficeMovie> CreateObjectReader() => new BoxOfficeMovieObjectJsonReader();

        public IArrayJsonReader<ITraktBoxOfficeMovie> CreateArrayReader() => new BoxOfficeMovieArrayJsonReader();

        public IObjectJsonReader<ITraktBoxOfficeMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktBoxOfficeMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
