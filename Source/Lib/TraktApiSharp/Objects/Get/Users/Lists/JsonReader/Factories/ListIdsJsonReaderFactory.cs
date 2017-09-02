namespace TraktApiSharp.Objects.Get.Users.Lists.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class ListIdsJsonReaderFactory : IJsonReaderFactory<ITraktListIds>
    {
        public IObjectJsonReader<ITraktListIds> CreateObjectReader() => new TraktListIdsObjectJsonReader();

        public IArrayJsonReader<ITraktListIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktListIds)} is not supported.");
        }
    }
}
