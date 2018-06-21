namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class UserHiddenItemsPostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPostResponseNotFoundGroup> CreateObjectReader()
            => new UserHiddenItemsPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktUserHiddenItemsPostResponseNotFoundGroup> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserHiddenItemsPostResponseNotFoundGroup)} is not supported.");

        public IObjectJsonWriter<ITraktUserHiddenItemsPostResponseNotFoundGroup> CreateObjectWriter()
            => new UserHiddenItemsPostResponseNotFoundGroupObjectJsonWriter();
    }
}
