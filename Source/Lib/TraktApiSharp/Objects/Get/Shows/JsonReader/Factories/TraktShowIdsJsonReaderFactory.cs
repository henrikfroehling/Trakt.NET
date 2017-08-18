namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktShowIdsJsonReaderFactory : IJsonReaderFactory<ITraktShowIds>
    {
        public ITraktObjectJsonReader<ITraktShowIds> CreateObjectReader() => new TraktShowIdsObjectJsonReader();

        public IArrayJsonReader<ITraktShowIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowIds)} is not supported.");
        }
    }
}
