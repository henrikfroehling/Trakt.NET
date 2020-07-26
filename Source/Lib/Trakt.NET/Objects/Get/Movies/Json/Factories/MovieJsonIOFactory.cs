namespace TraktNet.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class MovieJsonIOFactory : IJsonIOFactory<ITraktMovie>
    {
        public IObjectJsonReader<ITraktMovie> CreateObjectReader() => new MovieObjectJsonReader();

        public IObjectJsonWriter<ITraktMovie> CreateObjectWriter() => new MovieObjectJsonWriter();
    }
}
