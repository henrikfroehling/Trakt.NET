namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSharingJsonReaderFactory : IJsonReaderFactory<ITraktSharing>
    {
        public ITraktObjectJsonReader<ITraktSharing> CreateObjectReader() => new TraktSharingObjectJsonReader();

        public IArrayJsonReader<ITraktSharing> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSharing)} is not supported.");
        }
    }
}
