namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserHiddenItemsPostJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPost>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPost> CreateObjectReader() => new UserHiddenItemsPostObjectJsonReader();

        public IObjectJsonWriter<ITraktUserHiddenItemsPost> CreateObjectWriter() => new UserHiddenItemsPostObjectJsonWriter();
    }
}
