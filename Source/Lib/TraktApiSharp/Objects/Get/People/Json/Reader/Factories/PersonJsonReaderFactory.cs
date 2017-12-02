namespace TraktApiSharp.Objects.Get.People.Json.Factories.Reader
{
    using Get.People.Json.Reader;
    using Objects.Json;
    using System;

    internal class PersonJsonReaderFactory : IJsonReaderFactory<ITraktPerson>
    {
        public IObjectJsonReader<ITraktPerson> CreateObjectReader() => new PersonObjectJsonReader();

        public IArrayJsonReader<ITraktPerson> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPerson)} is not supported.");
        }
    }
}
