namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktErrorJsonReaderFactory : IJsonReaderFactory<ITraktError>
    {
        public ITraktObjectJsonReader<ITraktError> CreateObjectReader() => new TraktErrorObjectJsonReader();

        public ITraktArrayJsonReader<ITraktError> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktError)} is not supported.");
        }
    }
}
