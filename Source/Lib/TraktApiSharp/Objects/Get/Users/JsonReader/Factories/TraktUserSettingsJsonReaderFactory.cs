namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserSettingsJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserSettings>
    {
        public ITraktObjectJsonReader<ITraktUserSettings> CreateObjectReader() => new TraktUserSettingsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserSettings> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserSettings)} is not supported.");
        }
    }
}
