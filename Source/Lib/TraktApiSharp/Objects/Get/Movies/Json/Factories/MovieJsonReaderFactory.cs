namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Objects.Json;

    internal class MovieJsonReaderFactory : IJsonReaderFactory<ITraktMovie>
    {
        public IObjectJsonReader<ITraktMovie> CreateObjectReader() => new MovieObjectJsonReader();

        public IArrayJsonReader<ITraktMovie> CreateArrayReader() => new MovieArrayJsonReader();
    }
}
