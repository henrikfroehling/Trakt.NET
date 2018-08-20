namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListItemsPostResponseGroupJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostResponseGroup>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostResponseGroup> CreateObjectReader()
            => new UserCustomListItemsPostResponseGroupObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPostResponseGroup> CreateArrayReader()
            => new UserCustomListItemsPostResponseGroupArrayJsonReader();

        public IObjectJsonWriter<ITraktUserCustomListItemsPostResponseGroup> CreateObjectWriter()
            => new UserCustomListItemsPostResponseGroupObjectJsonWriter();
    }
}
