namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserWatchingItemJsonIOFactory : IJsonIOFactory<ITraktUserWatchingItem>
    {
        public IObjectJsonReader<ITraktUserWatchingItem> CreateObjectReader() => new UserWatchingItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserWatchingItem> CreateArrayReader() => new UserWatchingItemArrayJsonReader();

        public IObjectJsonWriter<ITraktUserWatchingItem> CreateObjectWriter() => new UserWatchingItemObjectJsonWriter();
    }
}
