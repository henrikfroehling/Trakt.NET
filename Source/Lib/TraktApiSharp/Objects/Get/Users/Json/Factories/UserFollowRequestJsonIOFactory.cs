namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserFollowRequestJsonIOFactory : IJsonIOFactory<ITraktUserFollowRequest>
    {
        public IObjectJsonReader<ITraktUserFollowRequest> CreateObjectReader() => new UserFollowRequestObjectJsonReader();

        public IArrayJsonReader<ITraktUserFollowRequest> CreateArrayReader() => new UserFollowRequestArrayJsonReader();

        public IObjectJsonWriter<ITraktUserFollowRequest> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktUserFollowRequest> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
