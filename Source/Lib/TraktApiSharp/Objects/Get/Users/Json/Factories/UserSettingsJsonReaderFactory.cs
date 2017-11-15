namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Objects.Json;
    using System;

    internal class UserSettingsJsonReaderFactory : IJsonReaderFactory<ITraktUserSettings>
    {
        public IObjectJsonReader<ITraktUserSettings> CreateObjectReader() => new UserSettingsObjectJsonReader();

        public IArrayJsonReader<ITraktUserSettings> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserSettings)} is not supported.");
        }
    }
}
