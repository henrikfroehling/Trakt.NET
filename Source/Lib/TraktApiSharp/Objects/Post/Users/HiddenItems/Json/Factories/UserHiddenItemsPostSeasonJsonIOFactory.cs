namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class UserHiddenItemsPostSeasonJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPostSeason>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPostSeason> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktUserHiddenItemsPostSeason)} is not supported.");

        public IArrayJsonReader<ITraktUserHiddenItemsPostSeason> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserHiddenItemsPostSeason)} is not supported.");

        public IObjectJsonWriter<ITraktUserHiddenItemsPostSeason> CreateObjectWriter() => new UserHiddenItemsPostSeasonObjectJsonWriter();
    }
}
