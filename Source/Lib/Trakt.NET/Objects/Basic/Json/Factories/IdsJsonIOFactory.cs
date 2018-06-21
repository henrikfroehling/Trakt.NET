namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;
    using System;

    internal class IdsJsonIOFactory : IJsonIOFactory<ITraktIds>
    {
        public IObjectJsonReader<ITraktIds> CreateObjectReader() => new IdsObjectJsonReader();

        public IArrayJsonReader<ITraktIds> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktIds)} is not supported.");

        public IObjectJsonWriter<ITraktIds> CreateObjectWriter() => new IdsObjectJsonWriter();
    }
}
