namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserHiddenItemsPostResponseJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPostResponse>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPostResponse> CreateObjectReader()
            => new UserHiddenItemsPostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktUserHiddenItemsPostResponse> CreateObjectWriter()
            => new UserHiddenItemsPostResponseObjectJsonWriter();
    }
}
