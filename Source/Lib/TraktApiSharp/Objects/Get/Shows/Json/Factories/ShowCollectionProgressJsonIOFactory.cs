namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;
    using System;

    internal class ShowCollectionProgressJsonIOFactory : IJsonIOFactory<ITraktShowCollectionProgress>
    {
        public IObjectJsonReader<ITraktShowCollectionProgress> CreateObjectReader() => new ShowCollectionProgressObjectJsonReader();

        public IArrayJsonReader<ITraktShowCollectionProgress> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktShowCollectionProgress)} is not supported.");

        public IObjectJsonWriter<ITraktShowCollectionProgress> CreateObjectWriter() => new ShowCollectionProgressObjectJsonWriter();
    }
}
