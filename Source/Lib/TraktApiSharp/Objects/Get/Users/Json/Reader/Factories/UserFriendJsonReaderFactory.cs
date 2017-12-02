namespace TraktApiSharp.Objects.Get.Users.Json.Factories.Reader
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserFriendJsonReaderFactory : IJsonReaderFactory<ITraktUserFriend>
    {
        public IObjectJsonReader<ITraktUserFriend> CreateObjectReader() => new UserFriendObjectJsonReader();

        public IArrayJsonReader<ITraktUserFriend> CreateArrayReader() => new UserFriendArrayJsonReader();
    }
}
