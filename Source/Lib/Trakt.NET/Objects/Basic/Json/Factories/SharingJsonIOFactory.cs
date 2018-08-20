namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class SharingJsonIOFactory : IJsonIOFactory<ITraktSharing>
    {
        public IObjectJsonReader<ITraktSharing> CreateObjectReader() => new SharingObjectJsonReader();

        public IArrayJsonReader<ITraktSharing> CreateArrayReader() => new SharingArrayJsonReader();

        public IObjectJsonWriter<ITraktSharing> CreateObjectWriter() => new SharingObjectJsonWriter();
    }
}
