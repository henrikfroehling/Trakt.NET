namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class UserHiddenItemsPostJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPost>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktUserHiddenItemsPost)} is not supported.");

        public IArrayJsonReader<ITraktUserHiddenItemsPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserHiddenItemsPost)} is not supported.");

        public IObjectJsonWriter<ITraktUserHiddenItemsPost> CreateObjectWriter() => new UserHiddenItemsPostObjectJsonWriter();
    }
}
