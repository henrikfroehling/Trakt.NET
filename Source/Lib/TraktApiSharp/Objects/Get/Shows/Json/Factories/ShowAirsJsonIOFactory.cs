namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;
    using System;

    internal class ShowAirsJsonIOFactory : IJsonIOFactory<ITraktShowAirs>
    {
        public IObjectJsonReader<ITraktShowAirs> CreateObjectReader() => new ShowAirsObjectJsonReader();

        public IArrayJsonReader<ITraktShowAirs> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktShowAirs)} is not supported.");

        public IObjectJsonWriter<ITraktShowAirs> CreateObjectWriter() => new ShowAirsObjectJsonWriter();
    }
}
