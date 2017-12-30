namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;
    using System;

    internal class ShowCollectionProgressJsonReaderFactory : IJsonIOFactory<ITraktShowCollectionProgress>
    {
        public IObjectJsonReader<ITraktShowCollectionProgress> CreateObjectReader() => new ShowCollectionProgressObjectJsonReader();

        public IArrayJsonReader<ITraktShowCollectionProgress> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowCollectionProgress)} is not supported.");
        }

        public IObjectJsonReader<ITraktShowCollectionProgress> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktShowCollectionProgress> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
