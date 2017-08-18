namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserSettingsJsonReaderFactory : IJsonReaderFactory<ITraktUserSettings>
    {
        public ITraktObjectJsonReader<ITraktUserSettings> CreateObjectReader() => new TraktUserSettingsObjectJsonReader();

        public IArrayJsonReader<ITraktUserSettings> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserSettings)} is not supported.");
        }
    }
}
