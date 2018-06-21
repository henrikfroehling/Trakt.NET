namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class UserHiddenItemsRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsRemovePostResponse>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsRemovePostResponse> CreateObjectReader()
            => new UserHiddenItemsRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktUserHiddenItemsRemovePostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserHiddenItemsRemovePostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktUserHiddenItemsRemovePostResponse> CreateObjectWriter()
            => new UserHiddenItemsRemovePostResponseObjectJsonWriter();
    }
}
