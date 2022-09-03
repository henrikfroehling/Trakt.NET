namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsPostShowJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsPostShow>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsPostShow> CreateObjectReader() => new UserPersonalListItemsPostShowObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsPostShow> CreateObjectWriter() => new UserPersonalListItemsPostShowObjectJsonWriter();
    }
}
