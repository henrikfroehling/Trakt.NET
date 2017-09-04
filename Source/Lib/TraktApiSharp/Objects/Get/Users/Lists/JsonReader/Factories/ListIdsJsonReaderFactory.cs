namespace TraktApiSharp.Objects.Get.Users.Lists.JsonReader.Factories
{
    using Objects.JsonReader;
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
