namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListItemsPostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateObjectReader()
            => new UserCustomListItemsPostResponseNotFoundGroupObjectJsonReader();

        public IObjectJsonWriter<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateObjectWriter()
            => new UserCustomListItemsPostResponseNotFoundGroupObjectJsonWriter();
    }
}
