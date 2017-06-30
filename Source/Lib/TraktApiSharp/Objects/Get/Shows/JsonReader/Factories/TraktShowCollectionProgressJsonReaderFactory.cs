namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktShowCollectionProgressJsonReaderFactory : ITraktJsonReaderFactory<ITraktShowCollectionProgress>
    {
        public ITraktObjectJsonReader<ITraktShowCollectionProgress> CreateObjectReader() => new TraktShowCollectionProgressObjectJsonReader();

        public ITraktArrayJsonReader<ITraktShowCollectionProgress> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowCollectionProgress)} is not supported.");
        }
    }
}
