namespace TraktApiSharp.Objects.Get.Users.Lists.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktListItemJsonReaderFactory : ITraktJsonReaderFactory<ITraktListItem>
    {
        public ITraktObjectJsonReader<ITraktListItem> CreateObjectReader() => new TraktListItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktListItem> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktListItem)} is not supported.");
        }
    }
}
