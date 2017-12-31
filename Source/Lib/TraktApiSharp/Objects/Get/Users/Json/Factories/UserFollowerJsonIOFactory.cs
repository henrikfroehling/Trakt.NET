namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;

    internal class UserFollowerJsonIOFactory : IJsonIOFactory<ITraktUserFollower>
    {
        public IObjectJsonReader<ITraktUserFollower> CreateObjectReader() => new UserFollowerObjectJsonReader();

        public IArrayJsonReader<ITraktUserFollower> CreateArrayReader() => new UserFollowerArrayJsonReader();

        public IObjectJsonWriter<ITraktUserFollower> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktUserFollower> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
