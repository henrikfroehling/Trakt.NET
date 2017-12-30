namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserIdsJsonReaderFactory : IJsonIOFactory<ITraktUserIds>
    {
        public IObjectJsonReader<ITraktUserIds> CreateObjectReader() => new UserIdsObjectJsonReader();

        public IArrayJsonReader<ITraktUserIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserIds)} is not supported.");
        }

        public IObjectJsonReader<ITraktUserIds> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserIds> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
