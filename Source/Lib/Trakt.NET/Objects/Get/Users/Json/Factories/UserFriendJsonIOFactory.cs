namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserFriendJsonIOFactory : IJsonIOFactory<ITraktUserFriend>
    {
        public IObjectJsonReader<ITraktUserFriend> CreateObjectReader() => new UserFriendObjectJsonReader();

        public IObjectJsonWriter<ITraktUserFriend> CreateObjectWriter() => new UserFriendObjectJsonWriter();
    }
}
