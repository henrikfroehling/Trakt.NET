namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class NetworkJsonReaderFactory : IJsonIOFactory<ITraktNetwork>
    {
        public IObjectJsonReader<ITraktNetwork> CreateObjectReader() => new NetworkObjectJsonReader();

        public IArrayJsonReader<ITraktNetwork> CreateArrayReader() => new NetworkArrayJsonReader();

        public IObjectJsonReader<ITraktNetwork> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktNetwork> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
