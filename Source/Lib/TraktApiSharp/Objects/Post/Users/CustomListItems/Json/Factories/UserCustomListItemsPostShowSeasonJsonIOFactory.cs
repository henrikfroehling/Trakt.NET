namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class UserCustomListItemsPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostShowSeason>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostShowSeason> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktUserCustomListItemsPostShowSeason)} is not supported.");

        public IArrayJsonReader<ITraktUserCustomListItemsPostShowSeason> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostShowSeason)} is not supported.");

        public IObjectJsonWriter<ITraktUserCustomListItemsPostShowSeason> CreateObjectWriter() => new UserCustomListItemsPostShowSeasonObjectJsonWriter();
    }
}
