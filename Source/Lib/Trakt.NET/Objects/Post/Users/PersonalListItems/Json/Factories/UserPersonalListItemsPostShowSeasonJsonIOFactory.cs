namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsPostShowSeason>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsPostShowSeason> CreateObjectReader() => new UserPersonalListItemsPostShowSeasonObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsPostShowSeason> CreateObjectWriter() => new UserPersonalListItemsPostShowSeasonObjectJsonWriter();
    }
}
