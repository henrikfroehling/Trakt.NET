namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsPostResponseGroupJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsPostResponseGroup>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsPostResponseGroup> CreateObjectReader()
            => new UserPersonalListItemsPostResponseGroupObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsPostResponseGroup> CreateObjectWriter()
            => new UserPersonalListItemsPostResponseGroupObjectJsonWriter();
    }
}
