namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class UserCustomListItemsPostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostShowEpisode>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostShowEpisode> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktUserCustomListItemsPostShowEpisode)} is not supported.");

        public IArrayJsonReader<ITraktUserCustomListItemsPostShowEpisode> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostShowEpisode)} is not supported.");

        public IObjectJsonWriter<ITraktUserCustomListItemsPostShowEpisode> CreateObjectWriter() => new UserCustomListItemsPostShowEpisodeObjectJsonWriter();
    }
}
