namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsPostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsPostResponseNotFoundGroup> CreateObjectReader()
            => new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsPostResponseNotFoundGroup> CreateObjectWriter()
            => new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonWriter();
    }
}
