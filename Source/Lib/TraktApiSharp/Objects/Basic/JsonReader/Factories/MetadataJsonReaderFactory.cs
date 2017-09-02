namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
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
