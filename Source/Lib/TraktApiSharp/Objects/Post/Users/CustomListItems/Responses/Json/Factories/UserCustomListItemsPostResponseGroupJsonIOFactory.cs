namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class UserCustomListItemsPostResponseGroupJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostResponseGroup>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostResponseGroup> CreateObjectReader()
            => new UserCustomListItemsPostResponseGroupObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPostResponseGroup> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostResponseGroup)} is not supported.");

        public IObjectJsonWriter<ITraktUserCustomListItemsPostResponseGroup> CreateObjectWriter()
            => new UserCustomListItemsPostResponseGroupObjectJsonWriter();
    }
}
