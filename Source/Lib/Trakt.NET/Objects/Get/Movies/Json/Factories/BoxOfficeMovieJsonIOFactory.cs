namespace TraktNet.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class BoxOfficeMovieJsonIOFactory : IJsonIOFactory<ITraktBoxOfficeMovie>
    {
        public IObjectJsonReader<ITraktBoxOfficeMovie> CreateObjectReader() => new BoxOfficeMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktBoxOfficeMovie> CreateObjectWriter() => new BoxOfficeMovieObjectJsonWriter();
    }
}
