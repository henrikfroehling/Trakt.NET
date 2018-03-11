namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;
    using System;

    internal class AccountSettingsJsonIOFactory : IJsonIOFactory<ITraktAccountSettings>
    {
        public IObjectJsonReader<ITraktAccountSettings> CreateObjectReader() => new AccountSettingsObjectJsonReader();

        public IArrayJsonReader<ITraktAccountSettings> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktAccountSettings)} is not supported.");

        public IObjectJsonWriter<ITraktAccountSettings> CreateObjectWriter() => new AccountSettingsObjectJsonWriter();
    }
}
