namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class NetworkJsonReaderFactory : IJsonReaderFactory<ITraktNetwork>
    {
        public IObjectJsonReader<ITraktNetwork> CreateObjectReader() => new NetworkObjectJsonReader();

        public IArrayJsonReader<ITraktNetwork> CreateArrayReader() => new NetworkArrayJsonReader();
    }
}
