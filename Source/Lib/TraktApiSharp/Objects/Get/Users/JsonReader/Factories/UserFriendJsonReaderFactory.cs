namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class UserFriendJsonReaderFactory : IJsonReaderFactory<ITraktUserFriend>
    {
        public IObjectJsonReader<ITraktUserFriend> CreateObjectReader() => new UserFriendObjectJsonReader();

        public IArrayJsonReader<ITraktUserFriend> CreateArrayReader() => new UserFriendArrayJsonReader();
    }
}
