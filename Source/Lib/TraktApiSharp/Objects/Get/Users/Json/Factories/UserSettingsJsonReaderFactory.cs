namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserSettingsJsonReaderFactory : IJsonIOFactory<ITraktUserSettings>
    {
        public IObjectJsonReader<ITraktUserSettings> CreateObjectReader() => new UserSettingsObjectJsonReader();

        public IArrayJsonReader<ITraktUserSettings> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserSettings)} is not supported.");
        }

        public IObjectJsonReader<ITraktUserSettings> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserSettings> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
