namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsRemovePostJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsRemovePost>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsRemovePost> CreateObjectReader() => new UserPersonalListItemsRemovePostObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsRemovePost> CreateObjectWriter() => new UserPersonalListItemsRemovePostObjectJsonWriter();
    }
}
