namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class MovieJsonIOFactory : IJsonIOFactory<ITraktMovie>
    {
        public IObjectJsonReader<ITraktMovie> CreateObjectReader() => new MovieObjectJsonReader();

        public IArrayJsonReader<ITraktMovie> CreateArrayReader() => new MovieArrayJsonReader();

        public IObjectJsonWriter<ITraktMovie> CreateObjectWriter() => new MovieObjectJsonWriter();
    }
}
