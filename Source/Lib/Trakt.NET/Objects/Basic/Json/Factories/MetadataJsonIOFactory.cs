namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class MetadataJsonIOFactory : IJsonIOFactory<ITraktMetadata>
    {
        public IObjectJsonReader<ITraktMetadata> CreateObjectReader() => new MetadataObjectJsonReader();

        public IArrayJsonReader<ITraktMetadata> CreateArrayReader() => new MetadataArrayJsonReader();

        public IObjectJsonWriter<ITraktMetadata> CreateObjectWriter() => new MetadataObjectJsonWriter();
    }
}
