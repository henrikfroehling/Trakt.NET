namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktGenreJsonReaderFactory : IJsonReaderFactory<ITraktGenre>
    {
        public ITraktObjectJsonReader<ITraktGenre> CreateObjectReader() => new TraktGenreObjectJsonReader();

        public ITraktArrayJsonReader<ITraktGenre> CreateArrayReader() => new TraktGenreArrayJsonReader();
    }
}
