namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsPostJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsPost>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsPost> CreateObjectReader() => new UserPersonalListItemsPostObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsPost> CreateObjectWriter() => new UserPersonalListItemsPostObjectJsonWriter();
    }
}
