namespace TraktNet.Objects.Post.Users.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListPostJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListPost>
    {
        public IObjectJsonReader<ITraktUserPersonalListPost> CreateObjectReader() => new UserPersonalListPostObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListPost> CreateObjectWriter() => new UserPersonalListPostObjectJsonWriter();
    }
}
