namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSearchResultJsonReaderFactory : IJsonReaderFactory<ITraktSearchResult>
    {
        public ITraktObjectJsonReader<ITraktSearchResult> CreateObjectReader() => new TraktSearchResultObjectJsonReader();

        public IArrayJsonReader<ITraktSearchResult> CreateArrayReader() => new TraktSearchResultArrayJsonReader();
    }
}
