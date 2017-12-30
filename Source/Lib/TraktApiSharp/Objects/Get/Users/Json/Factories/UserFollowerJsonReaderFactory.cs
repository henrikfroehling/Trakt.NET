namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserFollowerJsonReaderFactory : IJsonIOFactory<ITraktUserFollower>
    {
        public IObjectJsonReader<ITraktUserFollower> CreateObjectReader() => new UserFollowerObjectJsonReader();

        public IArrayJsonReader<ITraktUserFollower> CreateArrayReader() => new UserFollowerArrayJsonReader();

        public IObjectJsonReader<ITraktUserFollower> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserFollower> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
