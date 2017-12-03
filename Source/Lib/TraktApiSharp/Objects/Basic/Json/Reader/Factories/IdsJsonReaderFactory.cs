namespace TraktApiSharp.Objects.Basic.Json.Factories.Reader
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class IdsJsonReaderFactory : IJsonReaderFactory<ITraktIds>
    {
        public IObjectJsonReader<ITraktIds> CreateObjectReader() => new IdsObjectJsonReader();

        public IArrayJsonReader<ITraktIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktIds)} is not supported.");
        }
    }
}
