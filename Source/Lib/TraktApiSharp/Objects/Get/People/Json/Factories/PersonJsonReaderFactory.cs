namespace TraktApiSharp.Objects.Get.People.Json.Factories
{
    using Get.People.Json.Reader;
    using Objects.Json;
    using System;

    internal class PersonJsonReaderFactory : IJsonIOFactory<ITraktPerson>
    {
        public IObjectJsonReader<ITraktPerson> CreateObjectReader() => new PersonObjectJsonReader();

        public IArrayJsonReader<ITraktPerson> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPerson)} is not supported.");
        }

        public IObjectJsonReader<ITraktPerson> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktPerson> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
