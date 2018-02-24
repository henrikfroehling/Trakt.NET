namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class UserCustomListItemsPostJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPost>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktUserCustomListItemsPost)} is not supported.");

        public IArrayJsonReader<ITraktUserCustomListItemsPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPost)} is not supported.");

        public IObjectJsonWriter<ITraktUserCustomListItemsPost> CreateObjectWriter() => new UserCustomListItemsPostObjectJsonWriter();
    }
}
