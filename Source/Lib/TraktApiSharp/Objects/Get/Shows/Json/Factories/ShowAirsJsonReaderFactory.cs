namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Objects.Json;
    using System;

    internal class ShowAirsJsonReaderFactory : IJsonReaderFactory<ITraktShowAirs>
    {
        public IObjectJsonReader<ITraktShowAirs> CreateObjectReader() => new ShowAirsObjectJsonReader();

        public IArrayJsonReader<ITraktShowAirs> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowAirs)} is not supported.");
        }
    }
}
