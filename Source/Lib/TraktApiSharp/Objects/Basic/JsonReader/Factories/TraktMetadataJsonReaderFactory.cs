namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktMetadataJsonReaderFactory : IJsonReaderFactory<ITraktMetadata>
    {
        public ITraktObjectJsonReader<ITraktMetadata> CreateObjectReader() => new TraktMetadataObjectJsonReader();

        public IArrayJsonReader<ITraktMetadata> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMetadata)} is not supported.");
        }
    }
}
