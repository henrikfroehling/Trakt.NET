namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;
    using System;

    internal class AccountSettingsJsonReaderFactory : IJsonIOFactory<ITraktAccountSettings>
    {
        public IObjectJsonReader<ITraktAccountSettings> CreateObjectReader() => new AccountSettingsObjectJsonReader();

        public IArrayJsonReader<ITraktAccountSettings> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktAccountSettings)} is not supported.");
        }

        public IObjectJsonReader<ITraktAccountSettings> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktAccountSettings> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
