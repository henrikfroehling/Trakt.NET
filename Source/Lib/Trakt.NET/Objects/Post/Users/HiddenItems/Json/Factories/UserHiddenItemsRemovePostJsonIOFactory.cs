namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserHiddenItemsRemovePostJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsRemovePost>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsRemovePost> CreateObjectReader() => new UserHiddenItemsRemovePostObjectJsonReader();

        public IObjectJsonWriter<ITraktUserHiddenItemsRemovePost> CreateObjectWriter() => new UserHiddenItemsRemovePostObjectJsonWriter();
    }
}
