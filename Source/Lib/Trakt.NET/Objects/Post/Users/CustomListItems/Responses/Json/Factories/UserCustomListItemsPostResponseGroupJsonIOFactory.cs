namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListItemsPostResponseGroupJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostResponseGroup>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostResponseGroup> CreateObjectReader()
            => new UserCustomListItemsPostResponseGroupObjectJsonReader();

        public IObjectJsonWriter<ITraktUserCustomListItemsPostResponseGroup> CreateObjectWriter()
            => new UserCustomListItemsPostResponseGroupObjectJsonWriter();
    }
}
