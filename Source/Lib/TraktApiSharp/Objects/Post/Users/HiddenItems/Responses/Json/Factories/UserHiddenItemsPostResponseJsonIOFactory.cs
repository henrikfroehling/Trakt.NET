namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class UserHiddenItemsPostResponseJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPostResponse>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPostResponse> CreateObjectReader()
            => new UserHiddenItemsPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktUserHiddenItemsPostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserHiddenItemsPostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktUserHiddenItemsPostResponse> CreateObjectWriter()
            => new UserHiddenItemsPostResponseObjectJsonWriter();
    }
}
