namespace TraktApiSharp.Objects.Get.Users.Json.Factories
{
    using Objects.Json;
    using System;

    internal class UserImagesJsonReaderFactory : IJsonReaderFactory<ITraktUserImages>
    {
        public IObjectJsonReader<ITraktUserImages> CreateObjectReader() => new UserImagesObjectJsonReader();

        public IArrayJsonReader<ITraktUserImages> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserImages)} is not supported.");
        }
    }
}
