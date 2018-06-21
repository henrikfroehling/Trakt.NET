namespace TraktNet.Objects.Post.Users.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class UserCustomListPostJsonIOFactory : IJsonIOFactory<ITraktUserCustomListPost>
    {
        public IObjectJsonReader<ITraktUserCustomListPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktUserCustomListPost)} is not supported.");

        public IArrayJsonReader<ITraktUserCustomListPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListPost)} is not supported.");

        public IObjectJsonWriter<ITraktUserCustomListPost> CreateObjectWriter() => new UserCustomListPostObjectJsonWriter();
    }
}
