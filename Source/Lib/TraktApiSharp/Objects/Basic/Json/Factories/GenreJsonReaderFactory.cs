namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Json;

    internal class GenreJsonReaderFactory : IJsonReaderFactory<ITraktGenre>
    {
        public IObjectJsonReader<ITraktGenre> CreateObjectReader() => new GenreObjectJsonReader();

        public IArrayJsonReader<ITraktGenre> CreateArrayReader() => new GenreArrayJsonReader();
    }
}
