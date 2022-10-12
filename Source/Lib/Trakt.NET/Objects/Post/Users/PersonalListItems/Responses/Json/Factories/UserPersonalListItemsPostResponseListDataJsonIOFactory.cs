namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsPostResponseListDataJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsPostResponseListData>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsPostResponseListData> CreateObjectReader()
            => new UserPersonalListItemsPostResponseListDataObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsPostResponseListData> CreateObjectWriter()
            => new UserPersonalListItemsPostResponseListDataObjectJsonWriter();
    }
}
