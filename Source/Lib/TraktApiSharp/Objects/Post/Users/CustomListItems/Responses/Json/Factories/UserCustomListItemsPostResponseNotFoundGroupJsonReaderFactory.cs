namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using System;

    internal class UserCustomListItemsPostResponseNotFoundGroupJsonReaderFactory : IJsonReaderFactory<ITraktUserCustomListItemsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateObjectReader() => new UserCustomListItemsPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostResponseNotFoundGroup)} is not supported.");
        }
    }
}
