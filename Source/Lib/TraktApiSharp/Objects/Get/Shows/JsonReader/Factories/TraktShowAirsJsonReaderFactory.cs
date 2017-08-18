namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktShowAirsJsonReaderFactory : IJsonReaderFactory<ITraktShowAirs>
    {
        public ITraktObjectJsonReader<ITraktShowAirs> CreateObjectReader() => new TraktShowAirsObjectJsonReader();

        public IArrayJsonReader<ITraktShowAirs> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowAirs)} is not supported.");
        }
    }
}
