namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserCustomListItemsPostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostShowEpisode>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostShowEpisode> CreateObjectReader() => new UserCustomListItemsPostShowEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPostShowEpisode> CreateArrayReader() => new UserCustomListItemsPostShowEpisodeArrayJsonReader();

        public IObjectJsonWriter<ITraktUserCustomListItemsPostShowEpisode> CreateObjectWriter() => new UserCustomListItemsPostShowEpisodeObjectJsonWriter();
    }
}
