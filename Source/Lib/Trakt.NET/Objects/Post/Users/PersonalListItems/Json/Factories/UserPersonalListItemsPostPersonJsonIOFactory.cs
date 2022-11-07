namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsPostPersonJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsPostPerson>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsPostPerson> CreateObjectReader() => new UserPersonalListItemsPostPersonObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsPostPerson> CreateObjectWriter() => new UserPersonalListItemsPostPersonObjectJsonWriter();
    }
}
