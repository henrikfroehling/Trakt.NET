namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsPostEpisodeJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsPostEpisode>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsPostEpisode> CreateObjectReader() => new UserPersonalListItemsPostEpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsPostEpisode> CreateObjectWriter() => new UserPersonalListItemsPostEpisodeObjectJsonWriter();
    }
}
