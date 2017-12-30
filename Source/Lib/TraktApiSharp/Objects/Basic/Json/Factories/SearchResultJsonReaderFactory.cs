namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class SearchResultJsonReaderFactory : IJsonIOFactory<ITraktSearchResult>
    {
        public IObjectJsonReader<ITraktSearchResult> CreateObjectReader() => new SearchResultObjectJsonReader();

        public IArrayJsonReader<ITraktSearchResult> CreateArrayReader() => new SearchResultArrayJsonReader();

        public IObjectJsonReader<ITraktSearchResult> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktSearchResult> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
