namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class GenreJsonIOFactory : IJsonIOFactory<ITraktGenre>
    {
        public IObjectJsonReader<ITraktGenre> CreateObjectReader() => new GenreObjectJsonReader();

        public IArrayJsonReader<ITraktGenre> CreateArrayReader() => new GenreArrayJsonReader();

        public IObjectJsonWriter<ITraktGenre> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktGenre> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
