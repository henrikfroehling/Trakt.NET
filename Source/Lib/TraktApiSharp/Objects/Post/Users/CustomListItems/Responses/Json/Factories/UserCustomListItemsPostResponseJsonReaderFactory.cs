namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Users.CustomListItems.Responses.Json.Reader;
    using System;

    internal class UserCustomListItemsPostResponseJsonReaderFactory : IJsonIOFactory<ITraktUserCustomListItemsPostResponse>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostResponse> CreateObjectReader() => new UserCustomListItemsPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktUserCustomListItemsPostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserCustomListItemsPostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
