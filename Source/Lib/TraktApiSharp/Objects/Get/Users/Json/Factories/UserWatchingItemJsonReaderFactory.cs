namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserWatchingItemJsonReaderFactory : IJsonIOFactory<ITraktUserWatchingItem>
    {
        public IObjectJsonReader<ITraktUserWatchingItem> CreateObjectReader() => new UserWatchingItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserWatchingItem> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserWatchingItem)} is not supported.");
        }

        public IObjectJsonReader<ITraktUserWatchingItem> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserWatchingItem> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
