namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Objects.Json;

    internal class UserFollowRequestJsonReaderFactory : IJsonReaderFactory<ITraktUserFollowRequest>
    {
        public IObjectJsonReader<ITraktUserFollowRequest> CreateObjectReader() => new UserFollowRequestObjectJsonReader();

        public IArrayJsonReader<ITraktUserFollowRequest> CreateArrayReader() => new UserFollowRequestArrayJsonReader();
    }
}
