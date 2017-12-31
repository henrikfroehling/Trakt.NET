namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class BoxOfficeMovieJsonIOFactory : IJsonIOFactory<ITraktBoxOfficeMovie>
    {
        public IObjectJsonReader<ITraktBoxOfficeMovie> CreateObjectReader() => new BoxOfficeMovieObjectJsonReader();

        public IArrayJsonReader<ITraktBoxOfficeMovie> CreateArrayReader() => new BoxOfficeMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktBoxOfficeMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktBoxOfficeMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
