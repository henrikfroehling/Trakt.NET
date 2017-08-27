namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class IdsJsonReaderFactory : IJsonReaderFactory<ITraktIds>
    {
        public IObjectJsonReader<ITraktIds> CreateObjectReader() => new TraktIdsObjectJsonReader();

        public IArrayJsonReader<ITraktIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktIds)} is not supported.");
        }
    }
}
