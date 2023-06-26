namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class NetworkIdsJsonIOFactory : IJsonIOFactory<ITraktNetworkIds>
    {
        public IObjectJsonReader<ITraktNetworkIds> CreateObjectReader() => new NetworkIdsObjectJsonReader();

        public IObjectJsonWriter<ITraktNetworkIds> CreateObjectWriter() => new NetworkIdsObjectJsonWriter();
    }
}
