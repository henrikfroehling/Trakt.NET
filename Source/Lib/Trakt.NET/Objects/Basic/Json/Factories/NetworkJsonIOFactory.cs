namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class NetworkJsonIOFactory : IJsonIOFactory<ITraktNetwork>
    {
        public IObjectJsonReader<ITraktNetwork> CreateObjectReader() => new NetworkObjectJsonReader();

        public IArrayJsonReader<ITraktNetwork> CreateArrayReader() => new NetworkArrayJsonReader();

        public IObjectJsonWriter<ITraktNetwork> CreateObjectWriter() => new NetworkObjectJsonWriter();
    }
}
