namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class MetadataJsonReaderFactory : IJsonIOFactory<ITraktMetadata>
    {
        public IObjectJsonReader<ITraktMetadata> CreateObjectReader() => new MetadataObjectJsonReader();

        public IArrayJsonReader<ITraktMetadata> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMetadata)} is not supported.");
        }

        public IObjectJsonReader<ITraktMetadata> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktMetadata> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
