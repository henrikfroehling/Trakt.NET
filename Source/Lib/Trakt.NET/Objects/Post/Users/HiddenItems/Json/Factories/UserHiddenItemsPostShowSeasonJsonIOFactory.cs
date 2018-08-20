namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserHiddenItemsPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPostShowSeason>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPostShowSeason> CreateObjectReader()
            => new UserHiddenItemsPostShowSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktUserHiddenItemsPostShowSeason> CreateArrayReader()
            => new UserHiddenItemsPostShowSeasonArrayJsonReader();

        public IObjectJsonWriter<ITraktUserHiddenItemsPostShowSeason> CreateObjectWriter()
            => new UserHiddenItemsPostShowSeasonObjectJsonWriter();
    }
}
