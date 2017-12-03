namespace TraktApiSharp.Objects.Basic.Json.Factories.Reader
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class MetadataJsonReaderFactory : IJsonReaderFactory<ITraktMetadata>
    {
        public IObjectJsonReader<ITraktMetadata> CreateObjectReader() => new MetadataObjectJsonReader();

        public IArrayJsonReader<ITraktMetadata> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMetadata)} is not supported.");
        }
    }
}
