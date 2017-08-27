namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class SharingJsonReaderFactory : IJsonReaderFactory<ITraktSharing>
    {
        public IObjectJsonReader<ITraktSharing> CreateObjectReader() => new TraktSharingObjectJsonReader();

        public IArrayJsonReader<ITraktSharing> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSharing)} is not supported.");
        }
    }
}
