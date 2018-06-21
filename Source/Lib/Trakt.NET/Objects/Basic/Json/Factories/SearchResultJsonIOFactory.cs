namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class SearchResultJsonIOFactory : IJsonIOFactory<ITraktSearchResult>
    {
        public IObjectJsonReader<ITraktSearchResult> CreateObjectReader() => new SearchResultObjectJsonReader();

        public IArrayJsonReader<ITraktSearchResult> CreateArrayReader() => new SearchResultArrayJsonReader();

        public IObjectJsonWriter<ITraktSearchResult> CreateObjectWriter() => new SearchResultObjectJsonWriter();
    }
}
