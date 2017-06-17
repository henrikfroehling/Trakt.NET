namespace TraktApiSharp.Objects.Get.Watched.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktWatchedShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktWatchedShow>
    {
        public ITraktObjectJsonReader<ITraktWatchedShow> CreateObjectReader() => new TraktWatchedShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktWatchedShow> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktWatchedShow)} is not supported.");
        }
    }
}
