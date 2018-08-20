namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class AccountSettingsJsonIOFactory : IJsonIOFactory<ITraktAccountSettings>
    {
        public IObjectJsonReader<ITraktAccountSettings> CreateObjectReader() => new AccountSettingsObjectJsonReader();

        public IArrayJsonReader<ITraktAccountSettings> CreateArrayReader() => new AccountSettingsArrayJsonReader();

        public IObjectJsonWriter<ITraktAccountSettings> CreateObjectWriter() => new AccountSettingsObjectJsonWriter();
    }
}
