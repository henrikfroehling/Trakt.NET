namespace TraktApiSharp.Objects.Get.Collections.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktCollectionShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktCollectionShow>
    {
        public ITraktObjectJsonReader<ITraktCollectionShow> CreateObjectReader() => new TraktCollectionShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCollectionShow> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCollectionShow)} is not supported.");
        }
    }
}
