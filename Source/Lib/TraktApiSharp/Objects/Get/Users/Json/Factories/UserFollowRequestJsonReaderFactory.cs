namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserFollowRequestJsonReaderFactory : IJsonIOFactory<ITraktUserFollowRequest>
    {
        public IObjectJsonReader<ITraktUserFollowRequest> CreateObjectReader() => new UserFollowRequestObjectJsonReader();

        public IArrayJsonReader<ITraktUserFollowRequest> CreateArrayReader() => new UserFollowRequestArrayJsonReader();

        public IObjectJsonReader<ITraktUserFollowRequest> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserFollowRequest> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
