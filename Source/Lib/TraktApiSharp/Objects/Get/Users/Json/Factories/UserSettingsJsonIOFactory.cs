namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;
    using System;

    internal class UserSettingsJsonIOFactory : IJsonIOFactory<ITraktUserSettings>
    {
        public IObjectJsonReader<ITraktUserSettings> CreateObjectReader() => new UserSettingsObjectJsonReader();

        public IArrayJsonReader<ITraktUserSettings> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserSettings)} is not supported.");

        public IObjectJsonWriter<ITraktUserSettings> CreateObjectWriter() => new UserSettingsObjectJsonWriter();
    }
}
