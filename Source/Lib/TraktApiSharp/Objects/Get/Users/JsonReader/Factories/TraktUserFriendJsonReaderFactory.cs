namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserFriendJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserFriend>
    {
        public ITraktObjectJsonReader<ITraktUserFriend> CreateObjectReader() => new TraktUserFriendObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserFriend> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserFriend)} is not supported.");
        }
    }
}
