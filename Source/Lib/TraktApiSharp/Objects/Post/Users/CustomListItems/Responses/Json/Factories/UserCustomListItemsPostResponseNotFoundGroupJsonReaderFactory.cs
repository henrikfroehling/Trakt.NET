namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Users.CustomListItems.Responses.Json.Reader;
    using System;

    internal class UserCustomListItemsPostResponseNotFoundGroupJsonReaderFactory : IJsonIOFactory<ITraktUserCustomListItemsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateObjectReader() => new UserCustomListItemsPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostResponseNotFoundGroup)} is not supported.");
        }

        public IObjectJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
