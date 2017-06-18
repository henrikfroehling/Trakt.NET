namespace TraktApiSharp.Objects.Get.Users.Lists.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktListIdsJsonReaderFactory : ITraktJsonReaderFactory<ITraktListIds>
    {
        public ITraktObjectJsonReader<ITraktListIds> CreateObjectReader() => new TraktListIdsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktListIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktListIds)} is not supported.");
        }
    }
}
