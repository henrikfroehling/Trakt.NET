namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserFollowRequestJsonIOFactory : IJsonIOFactory<ITraktUserFollowRequest>
    {
        public IObjectJsonReader<ITraktUserFollowRequest> CreateObjectReader() => new UserFollowRequestObjectJsonReader();

        public IObjectJsonWriter<ITraktUserFollowRequest> CreateObjectWriter() => new UserFollowRequestObjectJsonWriter();
    }
}
