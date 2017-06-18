namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktMostAnticipatedShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktMostAnticipatedShow>
    {
        public ITraktObjectJsonReader<ITraktMostAnticipatedShow> CreateObjectReader() => new TraktMostAnticipatedShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMostAnticipatedShow> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMostAnticipatedShow)} is not supported.");
        }
    }
}
