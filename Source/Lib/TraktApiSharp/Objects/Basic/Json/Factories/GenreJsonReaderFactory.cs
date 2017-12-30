namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class GenreJsonReaderFactory : IJsonIOFactory<ITraktGenre>
    {
        public IObjectJsonReader<ITraktGenre> CreateObjectReader() => new GenreObjectJsonReader();

        public IArrayJsonReader<ITraktGenre> CreateArrayReader() => new GenreArrayJsonReader();

        public IObjectJsonReader<ITraktGenre> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktGenre> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
