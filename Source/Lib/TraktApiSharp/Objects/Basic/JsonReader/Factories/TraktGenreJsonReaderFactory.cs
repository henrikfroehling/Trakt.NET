namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktGenreJsonReaderFactory : IJsonReaderFactory<ITraktGenre>
    {
        public ITraktObjectJsonReader<ITraktGenre> CreateObjectReader() => new TraktGenreObjectJsonReader();

        public IArrayJsonReader<ITraktGenre> CreateArrayReader() => new TraktGenreArrayJsonReader();
    }
}
