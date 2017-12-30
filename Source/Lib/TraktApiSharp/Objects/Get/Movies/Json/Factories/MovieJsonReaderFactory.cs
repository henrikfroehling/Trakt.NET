namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class MovieJsonReaderFactory : IJsonIOFactory<ITraktMovie>
    {
        public IObjectJsonReader<ITraktMovie> CreateObjectReader() => new MovieObjectJsonReader();

        public IArrayJsonReader<ITraktMovie> CreateArrayReader() => new MovieArrayJsonReader();

        public IObjectJsonReader<ITraktMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
