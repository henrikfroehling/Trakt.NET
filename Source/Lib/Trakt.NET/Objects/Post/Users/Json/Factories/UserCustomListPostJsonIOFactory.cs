namespace TraktNet.Objects.Post.Users.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListPostJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListPost>
    {
        public IObjectJsonReader<ITraktUserPersonalListPost> CreateObjectReader() => new UserCustomListPostObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListPost> CreateObjectWriter() => new UserCustomListPostObjectJsonWriter();
    }
}
