namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListItemsPostShowJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostShow>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostShow> CreateObjectReader() => new UserCustomListItemsPostShowObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPostShow> CreateArrayReader() => new UserCustomListItemsPostShowArrayJsonReader();

        public IObjectJsonWriter<ITraktUserCustomListItemsPostShow> CreateObjectWriter() => new UserCustomListItemsPostShowObjectJsonWriter();
    }
}
