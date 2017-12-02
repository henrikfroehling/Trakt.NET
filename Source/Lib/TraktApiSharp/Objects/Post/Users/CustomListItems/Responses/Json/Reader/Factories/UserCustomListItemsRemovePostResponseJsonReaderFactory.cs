namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Users.CustomListItems.Responses.Json.Reader;
    using System;

    internal class UserCustomListItemsRemovePostResponseJsonReaderFactory : IJsonReaderFactory<ITraktUserCustomListItemsRemovePostResponse>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsRemovePostResponse> CreateObjectReader() => new UserCustomListItemsRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsRemovePostResponse)} is not supported.");
        }
    }
}
