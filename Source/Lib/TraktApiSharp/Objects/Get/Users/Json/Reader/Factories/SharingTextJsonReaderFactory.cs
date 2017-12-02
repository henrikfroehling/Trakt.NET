namespace TraktApiSharp.Objects.Get.Users.Json.Factories.Reader
{
    using Get.Users.Json.Reader;
    using Objects.Json;
    using System;

    internal class SharingTextJsonReaderFactory : IJsonReaderFactory<ITraktSharingText>
    {
        public IObjectJsonReader<ITraktSharingText> CreateObjectReader() => new SharingTextObjectJsonReader();

        public IArrayJsonReader<ITraktSharingText> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSharingText)} is not supported.");
        }
    }
}
