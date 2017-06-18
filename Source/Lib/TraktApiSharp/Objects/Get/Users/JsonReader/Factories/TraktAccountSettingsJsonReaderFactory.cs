namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktAccountSettingsJsonReaderFactory : ITraktJsonReaderFactory<ITraktAccountSettings>
    {
        public ITraktObjectJsonReader<ITraktAccountSettings> CreateObjectReader() => new TraktAccountSettingsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktAccountSettings> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktAccountSettings)} is not supported.");
        }
    }
}
