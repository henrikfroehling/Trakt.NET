namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Objects.Json;
    using System;

    internal class ShowIdsJsonReaderFactory : IJsonReaderFactory<ITraktShowIds>
    {
        public IObjectJsonReader<ITraktShowIds> CreateObjectReader() => new ShowIdsObjectJsonReader();

        public IArrayJsonReader<ITraktShowIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowIds)} is not supported.");
        }
    }
}
