namespace TraktApiSharp.Objects.Get.People.Json.Factories
{
    using Get.People.Json.Reader;
    using Get.People.Json.Writer;
    using Objects.Json;
    using System;

    internal class PersonJsonIOFactory : IJsonIOFactory<ITraktPerson>
    {
        public IObjectJsonReader<ITraktPerson> CreateObjectReader() => new PersonObjectJsonReader();

        public IArrayJsonReader<ITraktPerson> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktPerson)} is not supported.");

        public IObjectJsonWriter<ITraktPerson> CreateObjectWriter() => new PersonObjectJsonWriter();
    }
}
