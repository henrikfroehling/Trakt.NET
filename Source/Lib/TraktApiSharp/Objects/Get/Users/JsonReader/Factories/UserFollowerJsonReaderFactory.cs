namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class UserFollowerJsonReaderFactory : IJsonReaderFactory<ITraktUserFollower>
    {
        public IObjectJsonReader<ITraktUserFollower> CreateObjectReader() => new UserFollowerObjectJsonReader();

        public IArrayJsonReader<ITraktUserFollower> CreateArrayReader() => new UserFollowerArrayJsonReader();
    }
}
