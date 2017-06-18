namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktShowAirsJsonReaderFactory : ITraktJsonReaderFactory<ITraktShowAirs>
    {
        public ITraktObjectJsonReader<ITraktShowAirs> CreateObjectReader() => new TraktShowAirsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktShowAirs> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowAirs)} is not supported.");
        }
    }
}
