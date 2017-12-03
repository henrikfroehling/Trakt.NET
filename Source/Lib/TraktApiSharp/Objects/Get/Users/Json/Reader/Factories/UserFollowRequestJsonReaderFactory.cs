namespace TraktApiSharp.Objects.Get.Users.Json.Factories.Reader
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserFollowRequestJsonReaderFactory : IJsonReaderFactory<ITraktUserFollowRequest>
    {
        public IObjectJsonReader<ITraktUserFollowRequest> CreateObjectReader() => new UserFollowRequestObjectJsonReader();

        public IArrayJsonReader<ITraktUserFollowRequest> CreateArrayReader() => new UserFollowRequestArrayJsonReader();
    }
}
