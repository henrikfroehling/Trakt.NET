namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class SearchResultJsonIOFactory : IJsonIOFactory<ITraktSearchResult>
    {
        public IObjectJsonReader<ITraktSearchResult> CreateObjectReader() => new SearchResultObjectJsonReader();

        public IArrayJsonReader<ITraktSearchResult> CreateArrayReader() => new SearchResultArrayJsonReader();

        public IObjectJsonWriter<ITraktSearchResult> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSearchResult> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
