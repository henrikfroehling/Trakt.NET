namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Objects.Json;

    internal class UserHiddenItemJsonReaderFactory : IJsonReaderFactory<ITraktUserHiddenItem>
    {
        public IObjectJsonReader<ITraktUserHiddenItem> CreateObjectReader() => new UserHiddenItemObjectJsonReader();

        public IArrayJsonReader<ITraktUserHiddenItem> CreateArrayReader() => new UserHiddenItemArrayJsonReader();
    }
}
