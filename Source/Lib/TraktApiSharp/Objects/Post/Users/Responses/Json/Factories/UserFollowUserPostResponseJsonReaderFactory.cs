namespace TraktApiSharp.Objects.Post.Users.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Users.Responses.Json.Reader;
    using System;

    internal class UserFollowUserPostResponseJsonReaderFactory : IJsonIOFactory<ITraktUserFollowUserPostResponse>
    {
        public IObjectJsonReader<ITraktUserFollowUserPostResponse> CreateObjectReader() => new UserFollowUserPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktUserFollowUserPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserFollowUserPostResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktUserFollowUserPostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserFollowUserPostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
