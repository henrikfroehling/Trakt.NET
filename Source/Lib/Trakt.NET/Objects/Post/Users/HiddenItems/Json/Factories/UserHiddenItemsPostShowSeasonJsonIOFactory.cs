namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserHiddenItemsPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPostShowSeason>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPostShowSeason> CreateObjectReader()
            => new UserHiddenItemsPostShowSeasonObjectJsonReader();

        public IObjectJsonWriter<ITraktUserHiddenItemsPostShowSeason> CreateObjectWriter()
            => new UserHiddenItemsPostShowSeasonObjectJsonWriter();
    }
}
