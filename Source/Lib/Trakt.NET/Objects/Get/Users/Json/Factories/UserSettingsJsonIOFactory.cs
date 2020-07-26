namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserSettingsJsonIOFactory : IJsonIOFactory<ITraktUserSettings>
    {
        public IObjectJsonReader<ITraktUserSettings> CreateObjectReader() => new UserSettingsObjectJsonReader();

        public IObjectJsonWriter<ITraktUserSettings> CreateObjectWriter() => new UserSettingsObjectJsonWriter();
    }
}
