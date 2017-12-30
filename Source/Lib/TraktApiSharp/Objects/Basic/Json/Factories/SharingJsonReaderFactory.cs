namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class SharingJsonReaderFactory : IJsonIOFactory<ITraktSharing>
    {
        public IObjectJsonReader<ITraktSharing> CreateObjectReader() => new SharingObjectJsonReader();

        public IArrayJsonReader<ITraktSharing> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSharing)} is not supported.");
        }

        public IObjectJsonReader<ITraktSharing> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSharing> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
