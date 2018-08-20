namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListItemsPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostShowSeason>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostShowSeason> CreateObjectReader() => new UserCustomListItemsPostShowSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPostShowSeason> CreateArrayReader() => new UserCustomListItemsPostShowSeasonArrayJsonReader();

        public IObjectJsonWriter<ITraktUserCustomListItemsPostShowSeason> CreateObjectWriter() => new UserCustomListItemsPostShowSeasonObjectJsonWriter();
    }
}
