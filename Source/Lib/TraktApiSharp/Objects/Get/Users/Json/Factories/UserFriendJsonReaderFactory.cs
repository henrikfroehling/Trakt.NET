namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserFriendJsonReaderFactory : IJsonIOFactory<ITraktUserFriend>
    {
        public IObjectJsonReader<ITraktUserFriend> CreateObjectReader() => new UserFriendObjectJsonReader();

        public IArrayJsonReader<ITraktUserFriend> CreateArrayReader() => new UserFriendArrayJsonReader();

        public IObjectJsonReader<ITraktUserFriend> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserFriend> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
