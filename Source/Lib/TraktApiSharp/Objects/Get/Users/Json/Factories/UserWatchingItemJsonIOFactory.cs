namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserWatchingItemJsonIOFactory : IJsonIOFactory<ITraktUserWatchingItem>
    {
        public IObjectJsonReader<ITraktUserWatchingItem> CreateObjectReader() => new UserWatchingItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserWatchingItem> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserWatchingItem)} is not supported.");
        }

        public IObjectJsonWriter<ITraktUserWatchingItem> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktUserWatchingItem> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
