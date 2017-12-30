namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Users.CustomListItems.Responses.Json.Reader;
    using System;

    internal class UserCustomListItemsRemovePostResponseJsonReaderFactory : IJsonIOFactory<ITraktUserCustomListItemsRemovePostResponse>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsRemovePostResponse> CreateObjectReader() => new UserCustomListItemsRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsRemovePostResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktUserCustomListItemsRemovePostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserCustomListItemsRemovePostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
