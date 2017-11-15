namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Objects.Json;
    using System;

    internal class UserWatchingItemJsonReaderFactory : IJsonReaderFactory<ITraktUserWatchingItem>
    {
        public IObjectJsonReader<ITraktUserWatchingItem> CreateObjectReader() => new UserWatchingItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserWatchingItem> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserWatchingItem)} is not supported.");
        }
    }
}
