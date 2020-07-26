namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListItemsPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostShowSeason>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostShowSeason> CreateObjectReader() => new UserCustomListItemsPostShowSeasonObjectJsonReader();

        public IObjectJsonWriter<ITraktUserCustomListItemsPostShowSeason> CreateObjectWriter() => new UserCustomListItemsPostShowSeasonObjectJsonWriter();
    }
}
