namespace TraktApiSharp.Objects.Get.People.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktPersonIdsJsonReaderFactory : ITraktJsonReaderFactory<ITraktPersonIds>
    {
        public ITraktObjectJsonReader<ITraktPersonIds> CreateObjectReader() => new TraktPersonIdsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktPersonIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonIds)} is not supported.");
        }
    }
}
