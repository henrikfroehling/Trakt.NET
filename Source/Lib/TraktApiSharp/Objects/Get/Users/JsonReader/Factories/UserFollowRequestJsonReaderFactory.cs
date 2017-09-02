namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class UserFollowRequestJsonReaderFactory : IJsonReaderFactory<ITraktUserFollowRequest>
    {
        public IObjectJsonReader<ITraktUserFollowRequest> CreateObjectReader() => new UserFollowRequestObjectJsonReader();

        public IArrayJsonReader<ITraktUserFollowRequest> CreateArrayReader() => new UserFollowRequestArrayJsonReader();
    }
}
