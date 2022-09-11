namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class ConnectionsJsonIOFactory : IJsonIOFactory<ITraktConnections>
    {
        public IObjectJsonReader<ITraktConnections> CreateObjectReader() => new ConnectionsObjectJsonReader();

        public IObjectJsonWriter<ITraktConnections> CreateObjectWriter() => new ConnectionsObjectJsonWriter();
    }
}
