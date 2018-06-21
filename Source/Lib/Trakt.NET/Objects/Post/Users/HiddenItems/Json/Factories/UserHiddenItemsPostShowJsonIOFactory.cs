namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class UserHiddenItemsPostShowJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPostShow>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPostShow> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktUserHiddenItemsPostShow)} is not supported.");

        public IArrayJsonReader<ITraktUserHiddenItemsPostShow> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserHiddenItemsPostShow)} is not supported.");

        public IObjectJsonWriter<ITraktUserHiddenItemsPostShow> CreateObjectWriter() => new UserHiddenItemsPostShowObjectJsonWriter();
    }
}
