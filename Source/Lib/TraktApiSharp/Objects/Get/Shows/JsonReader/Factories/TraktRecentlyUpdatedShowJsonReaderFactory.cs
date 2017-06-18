namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktRecentlyUpdatedShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktRecentlyUpdatedShow>
    {
        public ITraktObjectJsonReader<ITraktRecentlyUpdatedShow> CreateObjectReader() => new TraktRecentlyUpdatedShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktRecentlyUpdatedShow> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktRecentlyUpdatedShow)} is not supported.");
        }
    }
}
