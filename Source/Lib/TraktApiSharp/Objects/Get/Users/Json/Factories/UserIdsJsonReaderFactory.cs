namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Objects.Json;
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
