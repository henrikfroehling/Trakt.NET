namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsPostSeasonJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsPostSeason>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsPostSeason> CreateObjectReader() => new UserPersonalListItemsPostSeasonObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsPostSeason> CreateObjectWriter() => new UserPersonalListItemsPostSeasonObjectJsonWriter();
    }
}
