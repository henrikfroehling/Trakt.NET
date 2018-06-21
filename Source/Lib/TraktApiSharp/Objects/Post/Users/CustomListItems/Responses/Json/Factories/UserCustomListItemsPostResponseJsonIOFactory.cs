namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class UserCustomListItemsPostResponseJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostResponse>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostResponse> CreateObjectReader()
            => new UserCustomListItemsPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktUserCustomListItemsPostResponse> CreateObjectWriter()
            => new UserCustomListItemsPostResponseObjectJsonWriter();
    }
}
