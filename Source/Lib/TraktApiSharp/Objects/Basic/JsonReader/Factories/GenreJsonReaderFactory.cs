namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class GenreJsonReaderFactory : IJsonReaderFactory<ITraktGenre>
    {
        public IObjectJsonReader<ITraktGenre> CreateObjectReader() => new TraktGenreObjectJsonReader();

        public IArrayJsonReader<ITraktGenre> CreateArrayReader() => new TraktGenreArrayJsonReader();
    }
}
