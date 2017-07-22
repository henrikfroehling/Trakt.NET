namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSearchResultJsonReaderFactory : ITraktJsonReaderFactory<ITraktSearchResult>
    {
        public ITraktObjectJsonReader<ITraktSearchResult> CreateObjectReader() => new TraktSearchResultObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSearchResult> CreateArrayReader() => new TraktSearchResultArrayJsonReader();
    }
}
