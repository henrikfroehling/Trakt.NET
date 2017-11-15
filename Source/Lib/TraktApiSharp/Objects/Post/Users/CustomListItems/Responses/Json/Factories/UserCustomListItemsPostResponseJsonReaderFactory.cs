namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using System;

    internal class UserCustomListItemsPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktUserCustomListItemsPostResponse>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostResponse> CreateObjectReader() => new UserCustomListItemsPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostResponse)} is not supported.");
        }
    }
}
