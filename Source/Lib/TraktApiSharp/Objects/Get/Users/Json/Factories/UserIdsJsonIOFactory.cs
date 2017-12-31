namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserIdsJsonIOFactory : IJsonIOFactory<ITraktUserIds>
    {
        public IObjectJsonReader<ITraktUserIds> CreateObjectReader() => new UserIdsObjectJsonReader();

        public IArrayJsonReader<ITraktUserIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserIds)} is not supported.");
        }

        public IObjectJsonWriter<ITraktUserIds> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktUserIds> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
