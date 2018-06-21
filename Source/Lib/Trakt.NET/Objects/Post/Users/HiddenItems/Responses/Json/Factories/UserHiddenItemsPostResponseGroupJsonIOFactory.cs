namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class UserHiddenItemsPostResponseGroupJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPostResponseGroup>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPostResponseGroup> CreateObjectReader()
            => new UserHiddenItemsPostResponseGroupObjectJsonReader();

        public IArrayJsonReader<ITraktUserHiddenItemsPostResponseGroup> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserHiddenItemsPostResponseGroup)} is not supported.");

        public IObjectJsonWriter<ITraktUserHiddenItemsPostResponseGroup> CreateObjectWriter()
            => new UserHiddenItemsPostResponseGroupObjectJsonWriter();
    }
}
