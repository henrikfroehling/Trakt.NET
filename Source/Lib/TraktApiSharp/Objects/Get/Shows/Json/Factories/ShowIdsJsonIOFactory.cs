namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;
    using System;

    internal class ShowIdsJsonIOFactory : IJsonIOFactory<ITraktShowIds>
    {
        public IObjectJsonReader<ITraktShowIds> CreateObjectReader() => new ShowIdsObjectJsonReader();

        public IArrayJsonReader<ITraktShowIds> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktShowIds)} is not supported.");

        public IObjectJsonWriter<ITraktShowIds> CreateObjectWriter() => new ShowIdsObjectJsonWriter();
    }
}
