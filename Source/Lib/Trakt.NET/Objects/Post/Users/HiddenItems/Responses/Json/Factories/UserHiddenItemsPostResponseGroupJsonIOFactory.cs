namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserHiddenItemsPostResponseGroupJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPostResponseGroup>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPostResponseGroup> CreateObjectReader()
            => new UserHiddenItemsPostResponseGroupObjectJsonReader();

        public IObjectJsonWriter<ITraktUserHiddenItemsPostResponseGroup> CreateObjectWriter()
            => new UserHiddenItemsPostResponseGroupObjectJsonWriter();
    }
}
