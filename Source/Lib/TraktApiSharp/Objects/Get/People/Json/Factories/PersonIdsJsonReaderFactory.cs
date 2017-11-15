namespace TraktApiSharp.Objects.Get.People.Json.Factories
{
    using Objects.Json;
    using System;

    internal class PersonIdsJsonReaderFactory : IJsonReaderFactory<ITraktPersonIds>
    {
        public IObjectJsonReader<ITraktPersonIds> CreateObjectReader() => new PersonIdsObjectJsonReader();

        public IArrayJsonReader<ITraktPersonIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonIds)} is not supported.");
        }
    }
}
