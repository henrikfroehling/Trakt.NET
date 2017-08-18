namespace TraktApiSharp.Objects.Get.Users.Lists.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktListIdsJsonReaderFactory : IJsonReaderFactory<ITraktListIds>
    {
        public ITraktObjectJsonReader<ITraktListIds> CreateObjectReader() => new TraktListIdsObjectJsonReader();

        public IArrayJsonReader<ITraktListIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktListIds)} is not supported.");
        }
    }
}
