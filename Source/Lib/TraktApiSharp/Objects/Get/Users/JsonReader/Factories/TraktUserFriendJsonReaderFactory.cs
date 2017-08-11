namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktUserFriendJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserFriend>
    {
        public ITraktObjectJsonReader<ITraktUserFriend> CreateObjectReader() => new TraktUserFriendObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserFriend> CreateArrayReader() => new TraktUserFriendArrayJsonReader();
    }
}
