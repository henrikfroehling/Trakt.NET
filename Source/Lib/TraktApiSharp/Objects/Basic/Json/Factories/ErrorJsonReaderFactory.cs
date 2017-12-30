namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class ErrorJsonReaderFactory : IJsonIOFactory<ITraktError>
    {
        public IObjectJsonReader<ITraktError> CreateObjectReader() => new ErrorObjectJsonReader();

        public IArrayJsonReader<ITraktError> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktError)} is not supported.");
        }

        public IObjectJsonReader<ITraktError> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktError> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
