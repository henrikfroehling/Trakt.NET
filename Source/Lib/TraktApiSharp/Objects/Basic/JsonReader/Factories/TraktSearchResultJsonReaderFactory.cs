namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSearchResultJsonReaderFactory : IJsonReaderFactory<ITraktSearchResult>
    {
        public ITraktObjectJsonReader<ITraktSearchResult> CreateObjectReader() => new TraktSearchResultObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSearchResult> CreateArrayReader() => new TraktSearchResultArrayJsonReader();
    }
}
