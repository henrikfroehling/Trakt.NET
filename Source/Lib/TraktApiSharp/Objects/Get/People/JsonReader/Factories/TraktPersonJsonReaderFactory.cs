namespace TraktApiSharp.Objects.Get.People.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktPersonJsonReaderFactory : ITraktJsonReaderFactory<ITraktPerson>
    {
        public ITraktObjectJsonReader<ITraktPerson> CreateObjectReader() => new TraktPersonObjectJsonReader();

        public ITraktArrayJsonReader<ITraktPerson> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPerson)} is not supported.");
        }
    }
}
