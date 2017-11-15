namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Objects.Json;

    internal class UserFollowerJsonReaderFactory : IJsonReaderFactory<ITraktUserFollower>
    {
        public IObjectJsonReader<ITraktUserFollower> CreateObjectReader() => new UserFollowerObjectJsonReader();

        public IArrayJsonReader<ITraktUserFollower> CreateArrayReader() => new UserFollowerArrayJsonReader();
    }
}
