namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktIdsJsonReaderFactory : IJsonReaderFactory<ITraktIds>
    {
        public ITraktObjectJsonReader<ITraktIds> CreateObjectReader() => new TraktIdsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktIds)} is not supported.");
        }
    }
}
