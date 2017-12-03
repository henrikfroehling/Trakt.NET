namespace TraktApiSharp.Objects.Basic.Json.Factories.Reader
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class ErrorJsonReaderFactory : IJsonReaderFactory<ITraktError>
    {
        public IObjectJsonReader<ITraktError> CreateObjectReader() => new ErrorObjectJsonReader();

        public IArrayJsonReader<ITraktError> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktError)} is not supported.");
        }
    }
}
