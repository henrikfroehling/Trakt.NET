namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktMostPWCShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktMostPWCShow>
    {
        public ITraktObjectJsonReader<ITraktMostPWCShow> CreateObjectReader() => new TraktMostPWCShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMostPWCShow> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMostPWCShow)} is not supported.");
        }
    }
}
