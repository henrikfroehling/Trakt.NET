namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class ErrorJsonIOFactory : IJsonIOFactory<ITraktError>
    {
        public IObjectJsonReader<ITraktError> CreateObjectReader() => new ErrorObjectJsonReader();

        public IArrayJsonReader<ITraktError> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktError)} is not supported.");
        }

        public IObjectJsonWriter<ITraktError> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktError> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
