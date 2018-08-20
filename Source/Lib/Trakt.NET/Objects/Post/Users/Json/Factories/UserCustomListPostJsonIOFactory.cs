namespace TraktNet.Objects.Post.Users.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListPostJsonIOFactory : IJsonIOFactory<ITraktUserCustomListPost>
    {
        public IObjectJsonReader<ITraktUserCustomListPost> CreateObjectReader() => new UserCustomListPostObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListPost> CreateArrayReader() => new UserCustomListPostArrayJsonReader();

        public IObjectJsonWriter<ITraktUserCustomListPost> CreateObjectWriter() => new UserCustomListPostObjectJsonWriter();
    }
}
