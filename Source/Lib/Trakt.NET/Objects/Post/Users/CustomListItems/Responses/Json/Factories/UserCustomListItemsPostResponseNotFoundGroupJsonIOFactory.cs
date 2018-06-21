namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class UserCustomListItemsPostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateObjectReader()
            => new UserCustomListItemsPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostResponseNotFoundGroup)} is not supported.");

        public IObjectJsonWriter<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateObjectWriter()
            => new UserCustomListItemsPostResponseNotFoundGroupObjectJsonWriter();
    }
}
