namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserListLimitsJsonIOFactory : IJsonIOFactory<ITraktUserListLimits>
    {
        public IObjectJsonReader<ITraktUserListLimits> CreateObjectReader() => new UserListLimitsObjectJsonReader();

        public IObjectJsonWriter<ITraktUserListLimits> CreateObjectWriter() => new UserListLimitsObjectJsonWriter();
    }
}
