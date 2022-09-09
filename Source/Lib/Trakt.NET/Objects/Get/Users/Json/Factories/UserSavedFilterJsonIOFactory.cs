namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserSavedFilterJsonIOFactory : IJsonIOFactory<ITraktUserSavedFilter>
    {
        public IObjectJsonReader<ITraktUserSavedFilter> CreateObjectReader() => new UserSavedFilterObjectJsonReader();

        public IObjectJsonWriter<ITraktUserSavedFilter> CreateObjectWriter() => new UserSavedFilterObjectJsonWriter();
    }
}
