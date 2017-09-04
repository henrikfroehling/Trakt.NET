namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
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
