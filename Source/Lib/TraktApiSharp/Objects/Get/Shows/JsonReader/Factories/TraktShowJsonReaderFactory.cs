namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktShow>
    {
        public ITraktObjectJsonReader<ITraktShow> CreateObjectReader() => new TraktShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktShow> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShow)} is not supported.");
        }
    }
}
