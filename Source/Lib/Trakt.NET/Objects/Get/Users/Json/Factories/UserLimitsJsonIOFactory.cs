namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserLimitsJsonIOFactory : IJsonIOFactory<ITraktUserLimits>
    {
        public IObjectJsonReader<ITraktUserLimits> CreateObjectReader() => new UserLimitsObjectJsonReader();

        public IObjectJsonWriter<ITraktUserLimits> CreateObjectWriter() => new UserLimitsObjectJsonWriter();
    }
}
