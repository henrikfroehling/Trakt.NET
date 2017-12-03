namespace TraktApiSharp.Objects.Get.Users.Lists.Json.Factories.Reader
{
    using Get.Users.Lists.Json.Reader;
    using Objects.Json;
    using System;

    internal class ListIdsJsonReaderFactory : IJsonReaderFactory<ITraktListIds>
    {
        public IObjectJsonReader<ITraktListIds> CreateObjectReader() => new ListIdsObjectJsonReader();

        public IArrayJsonReader<ITraktListIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktListIds)} is not supported.");
        }
    }
}
