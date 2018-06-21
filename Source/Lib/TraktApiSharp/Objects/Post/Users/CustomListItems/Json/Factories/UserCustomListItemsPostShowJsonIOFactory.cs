namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class UserCustomListItemsPostShowJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostShow>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostShow> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktUserCustomListItemsPostShow)} is not supported.");

        public IArrayJsonReader<ITraktUserCustomListItemsPostShow> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostShow)} is not supported.");

        public IObjectJsonWriter<ITraktUserCustomListItemsPostShow> CreateObjectWriter() => new UserCustomListItemsPostShowObjectJsonWriter();
    }
}
