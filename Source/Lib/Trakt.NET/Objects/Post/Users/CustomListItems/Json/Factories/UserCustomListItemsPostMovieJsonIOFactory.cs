namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class UserCustomListItemsPostMovieJsonIOFactory : IJsonIOFactory<ITraktUserCustomListItemsPostMovie>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostMovie> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktUserCustomListItemsPostMovie)} is not supported.");

        public IArrayJsonReader<ITraktUserCustomListItemsPostMovie> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostMovie)} is not supported.");

        public IObjectJsonWriter<ITraktUserCustomListItemsPostMovie> CreateObjectWriter() => new UserCustomListItemsPostMovieObjectJsonWriter();
    }
}
