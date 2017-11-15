namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Objects.Json;

    internal class UserFriendJsonReaderFactory : IJsonReaderFactory<ITraktUserFriend>
    {
        public IObjectJsonReader<ITraktUserFriend> CreateObjectReader() => new UserFriendObjectJsonReader();

        public IArrayJsonReader<ITraktUserFriend> CreateArrayReader() => new UserFriendArrayJsonReader();
    }
}
