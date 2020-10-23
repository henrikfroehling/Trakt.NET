namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserFollowerJsonIOFactory : IJsonIOFactory<ITraktUserFollower>
    {
        public IObjectJsonReader<ITraktUserFollower> CreateObjectReader() => new UserFollowerObjectJsonReader();

        public IObjectJsonWriter<ITraktUserFollower> CreateObjectWriter() => new UserFollowerObjectJsonWriter();
    }
}
