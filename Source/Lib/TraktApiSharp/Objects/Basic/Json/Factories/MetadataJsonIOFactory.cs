namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;
    using System;

    internal class MetadataJsonIOFactory : IJsonIOFactory<ITraktMetadata>
    {
        public IObjectJsonReader<ITraktMetadata> CreateObjectReader() => new MetadataObjectJsonReader();

        public IArrayJsonReader<ITraktMetadata> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktMetadata)} is not supported.");

        public IObjectJsonWriter<ITraktMetadata> CreateObjectWriter() => new MetadataObjectJsonWriter();
    }
}
