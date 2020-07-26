namespace TraktNet.Objects.Post.Users.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListsReorderPostJsonIOFactory : IJsonIOFactory<ITraktUserCustomListsReorderPost>
    {
        public IObjectJsonReader<ITraktUserCustomListsReorderPost> CreateObjectReader() => new UserCustomListsReorderPostObjectJsonReader();

        public IObjectJsonWriter<ITraktUserCustomListsReorderPost> CreateObjectWriter() => new UserCustomListsReorderPostObjectJsonWriter();
    }
}
