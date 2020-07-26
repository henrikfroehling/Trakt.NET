namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListItemsPostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostShowEpisode>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostShowEpisode> CreateObjectReader() => new UserCustomListItemsPostShowEpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktUserCustomListItemsPostShowEpisode> CreateObjectWriter() => new UserCustomListItemsPostShowEpisodeObjectJsonWriter();
    }
}
