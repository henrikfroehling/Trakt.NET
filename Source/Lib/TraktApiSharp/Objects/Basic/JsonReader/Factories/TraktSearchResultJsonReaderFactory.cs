namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSearchResultJsonReaderFactory : ITraktJsonReaderFactory<ITraktSearchResult>
    {
        public ITraktObjectJsonReader<ITraktSearchResult> CreateObjectReader() => new TraktSearchResultObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSearchResult> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSearchResult)} is not supported.");
        }
    }
}
