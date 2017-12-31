namespace TraktApiSharp.Objects.Get.People.Json.Factories
{
    using Get.People.Json.Reader;
    using Objects.Json;
    using System;

    internal class PersonIdsJsonIOFactory : IJsonIOFactory<ITraktPersonIds>
    {
        public IObjectJsonReader<ITraktPersonIds> CreateObjectReader() => new PersonIdsObjectJsonReader();

        public IArrayJsonReader<ITraktPersonIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonIds)} is not supported.");
        }

        public IObjectJsonWriter<ITraktPersonIds> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktPersonIds> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
