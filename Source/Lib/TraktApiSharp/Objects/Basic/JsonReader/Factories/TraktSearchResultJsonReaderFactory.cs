﻿namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSearchResultJsonReaderFactory : IJsonReaderFactory<ITraktSearchResult>
    {
        public IObjectJsonReader<ITraktSearchResult> CreateObjectReader() => new TraktSearchResultObjectJsonReader();

        public IArrayJsonReader<ITraktSearchResult> CreateArrayReader() => new TraktSearchResultArrayJsonReader();
    }
}
