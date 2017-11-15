namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Json;

    internal class NetworkJsonReaderFactory : IJsonReaderFactory<ITraktNetwork>
    {
        public IObjectJsonReader<ITraktNetwork> CreateObjectReader() => new NetworkObjectJsonReader();

        public IArrayJsonReader<ITraktNetwork> CreateArrayReader() => new NetworkArrayJsonReader();
    }
}
