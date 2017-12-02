namespace TraktApiSharp.Objects.Get.Users.Json.Factories.Reader
{
    using Get.Users.Json.Reader;
    using Objects.Json;
    using System;

    internal class AccountSettingsJsonReaderFactory : IJsonReaderFactory<ITraktAccountSettings>
    {
        public IObjectJsonReader<ITraktAccountSettings> CreateObjectReader() => new AccountSettingsObjectJsonReader();

        public IArrayJsonReader<ITraktAccountSettings> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktAccountSettings)} is not supported.");
        }
    }
}
