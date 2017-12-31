namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class SharingJsonIOFactory : IJsonIOFactory<ITraktSharing>
    {
        public IObjectJsonReader<ITraktSharing> CreateObjectReader() => new SharingObjectJsonReader();

        public IArrayJsonReader<ITraktSharing> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSharing)} is not supported.");
        }

        public IObjectJsonWriter<ITraktSharing> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSharing> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
