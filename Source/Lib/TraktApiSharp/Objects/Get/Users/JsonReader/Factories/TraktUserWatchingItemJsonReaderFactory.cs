namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserWatchingItemJsonReaderFactory : IJsonReaderFactory<ITraktUserWatchingItem>
    {
        public ITraktObjectJsonReader<ITraktUserWatchingItem> CreateObjectReader() => new TraktUserWatchingItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserWatchingItem> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserWatchingItem)} is not supported.");
        }
    }
}
