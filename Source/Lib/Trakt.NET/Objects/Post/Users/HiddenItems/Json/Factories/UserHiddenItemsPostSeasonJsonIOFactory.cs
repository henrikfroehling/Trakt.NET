namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserHiddenItemsPostSeasonJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPostSeason>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPostSeason> CreateObjectReader() => new UserHiddenItemsPostSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktUserHiddenItemsPostSeason> CreateArrayReader() => new UserHiddenItemsPostSeasonArrayJsonReader();

        public IObjectJsonWriter<ITraktUserHiddenItemsPostSeason> CreateObjectWriter() => new UserHiddenItemsPostSeasonObjectJsonWriter();
    }
}
