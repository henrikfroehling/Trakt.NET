namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class UserHiddenItemsPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPostShowSeason>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPostShowSeason> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktUserHiddenItemsPostShowSeason)} is not supported.");

        public IArrayJsonReader<ITraktUserHiddenItemsPostShowSeason> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserHiddenItemsPostShowSeason)} is not supported.");

        public IObjectJsonWriter<ITraktUserHiddenItemsPostShowSeason> CreateObjectWriter() => new UserHiddenItemsPostShowSeasonObjectJsonWriter();
    }
}
