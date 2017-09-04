namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class UserIdsJsonReaderFactory : IJsonReaderFactory<ITraktUserIds>
    {
        public IObjectJsonReader<ITraktUserIds> CreateObjectReader() => new UserIdsObjectJsonReader();

        public IArrayJsonReader<ITraktUserIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserIds)} is not supported.");
        }
    }
}
