namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;

    internal class NetworkJsonIOFactory : IJsonIOFactory<ITraktNetwork>
    {
        public IObjectJsonReader<ITraktNetwork> CreateObjectReader() => new NetworkObjectJsonReader();

        public IArrayJsonReader<ITraktNetwork> CreateArrayReader() => new NetworkArrayJsonReader();

        public IObjectJsonWriter<ITraktNetwork> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktNetwork> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
