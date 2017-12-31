namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Users.CustomListItems.Responses.Json.Reader;
    using System;

    internal class UserCustomListItemsPostResponseGroupJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostResponseGroup>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostResponseGroup> CreateObjectReader() => new UserCustomListItemsPostResponseGroupObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPostResponseGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostResponseGroup)} is not supported.");
        }

        public IObjectJsonWriter<ITraktUserCustomListItemsPostResponseGroup> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktUserCustomListItemsPostResponseGroup> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
