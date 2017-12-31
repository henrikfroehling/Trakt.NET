namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;
    using System;

    internal class SharingJsonIOFactory : IJsonIOFactory<ITraktSharing>
    {
        public IObjectJsonReader<ITraktSharing> CreateObjectReader() => new SharingObjectJsonReader();

        public IArrayJsonReader<ITraktSharing> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSharing)} is not supported.");

        public IObjectJsonWriter<ITraktSharing> CreateObjectWriter() => new SharingObjectJsonWriter();

        public IArrayJsonWriter<ITraktSharing> CreateArrayWriter()
            => throw new NotSupportedException($"A array json writer for {nameof(ITraktSharing)} is not supported.");
    }
}
