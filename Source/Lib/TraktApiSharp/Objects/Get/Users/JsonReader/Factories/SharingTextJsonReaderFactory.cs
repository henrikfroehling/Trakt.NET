namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class SharingTextJsonReaderFactory : IJsonReaderFactory<ITraktSharingText>
    {
        public IObjectJsonReader<ITraktSharingText> CreateObjectReader() => new TraktSharingTextObjectJsonReader();

        public IArrayJsonReader<ITraktSharingText> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSharingText)} is not supported.");
        }
    }
}
