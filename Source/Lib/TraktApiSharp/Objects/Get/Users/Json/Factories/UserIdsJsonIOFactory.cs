namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;
    using System;

    internal class UserIdsJsonIOFactory : IJsonIOFactory<ITraktUserIds>
    {
        public IObjectJsonReader<ITraktUserIds> CreateObjectReader() => new UserIdsObjectJsonReader();

        public IArrayJsonReader<ITraktUserIds> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserIds)} is not supported.");

        public IObjectJsonWriter<ITraktUserIds> CreateObjectWriter() => new UserIdsObjectJsonWriter();

        public IArrayJsonWriter<ITraktUserIds> CreateArrayWriter()
            => throw new NotSupportedException($"A array json writer for {nameof(ITraktUserIds)} is not supported.");
    }
}
