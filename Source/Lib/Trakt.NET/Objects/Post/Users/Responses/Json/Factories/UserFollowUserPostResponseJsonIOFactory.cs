namespace TraktNet.Objects.Post.Users.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class UserFollowUserPostResponseJsonIOFactory : IJsonIOFactory<ITraktUserFollowUserPostResponse>
    {
        public IObjectJsonReader<ITraktUserFollowUserPostResponse> CreateObjectReader() => new UserFollowUserPostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktUserFollowUserPostResponse> CreateObjectWriter() => new UserFollowUserPostResponseObjectJsonWriter();
    }
}
