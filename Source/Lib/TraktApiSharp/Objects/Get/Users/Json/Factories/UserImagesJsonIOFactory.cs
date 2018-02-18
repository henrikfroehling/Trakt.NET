namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;
    using System;

    internal class UserImagesJsonIOFactory : IJsonIOFactory<ITraktUserImages>
    {
        public IObjectJsonReader<ITraktUserImages> CreateObjectReader() => new UserImagesObjectJsonReader();

        public IArrayJsonReader<ITraktUserImages> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserImages)} is not supported.");

        public IObjectJsonWriter<ITraktUserImages> CreateObjectWriter() => new UserImagesObjectJsonWriter();

        public IArrayJsonWriter<ITraktUserImages> CreateArrayWriter()
            => throw new NotSupportedException($"A array json writer for {nameof(ITraktUserImages)} is not supported.");
    }
}
