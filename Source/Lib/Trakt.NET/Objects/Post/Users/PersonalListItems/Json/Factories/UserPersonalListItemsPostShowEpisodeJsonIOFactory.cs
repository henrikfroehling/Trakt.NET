namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserPersonalListItemsPostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktUserPersonalListItemsPostShowEpisode>
    {
        public IObjectJsonReader<ITraktUserPersonalListItemsPostShowEpisode> CreateObjectReader() => new UserPersonalListItemsPostShowEpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktUserPersonalListItemsPostShowEpisode> CreateObjectWriter() => new UserPersonalListItemsPostShowEpisodeObjectJsonWriter();
    }
}
