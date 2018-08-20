namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListItemsPostJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPost>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPost> CreateObjectReader() => new UserCustomListItemsPostObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPost> CreateArrayReader() => new UserCustomListItemsPostArrayJsonReader();

        public IObjectJsonWriter<ITraktUserCustomListItemsPost> CreateObjectWriter() => new UserCustomListItemsPostObjectJsonWriter();
    }
}
