namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserHiddenItemsRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsRemovePostResponse>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsRemovePostResponse> CreateObjectReader()
            => new UserHiddenItemsRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktUserHiddenItemsRemovePostResponse> CreateArrayReader()
            => new UserHiddenItemsRemovePostResponseArrayJsonReader();

        public IObjectJsonWriter<ITraktUserHiddenItemsRemovePostResponse> CreateObjectWriter()
            => new UserHiddenItemsRemovePostResponseObjectJsonWriter();
    }
}
