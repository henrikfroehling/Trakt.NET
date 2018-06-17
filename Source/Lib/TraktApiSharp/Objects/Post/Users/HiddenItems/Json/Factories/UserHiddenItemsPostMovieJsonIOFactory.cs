namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class UserHiddenItemsPostMovieJsonIOFactory : IJsonIOFactory<ITraktUserHiddenItemsPostMovie>
    {
        public IObjectJsonReader<ITraktUserHiddenItemsPostMovie> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktUserHiddenItemsPostMovie)} is not supported.");

        public IArrayJsonReader<ITraktUserHiddenItemsPostMovie> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserHiddenItemsPostMovie)} is not supported.");

        public IObjectJsonWriter<ITraktUserHiddenItemsPostMovie> CreateObjectWriter() => new UserHiddenItemsPostMovieObjectJsonWriter();
    }
}
