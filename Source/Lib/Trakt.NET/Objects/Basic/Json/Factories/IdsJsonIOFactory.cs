namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class IdsJsonIOFactory : IJsonIOFactory<ITraktIds>
    {
        public IObjectJsonReader<ITraktIds> CreateObjectReader() => new IdsObjectJsonReader();

        public IArrayJsonReader<ITraktIds> CreateArrayReader() => new IdsArrayJsonReader();

        public IObjectJsonWriter<ITraktIds> CreateObjectWriter() => new IdsObjectJsonWriter();
    }
}
