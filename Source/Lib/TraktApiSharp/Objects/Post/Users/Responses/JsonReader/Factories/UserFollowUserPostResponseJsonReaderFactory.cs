namespace TraktApiSharp.Objects.Post.Users.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class UserFollowUserPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktUserFollowUserPostResponse>
    {
        public IObjectJsonReader<ITraktUserFollowUserPostResponse> CreateObjectReader() => new UserFollowUserPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktUserFollowUserPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserFollowUserPostResponse)} is not supported.");
        }
    }
}
