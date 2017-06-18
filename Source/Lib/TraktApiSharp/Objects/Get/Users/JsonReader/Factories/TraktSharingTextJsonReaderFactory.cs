namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSharingTextJsonReaderFactory : ITraktJsonReaderFactory<ITraktSharingText>
    {
        public ITraktObjectJsonReader<ITraktSharingText> CreateObjectReader() => new TraktSharingTextObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSharingText> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSharingText)} is not supported.");
        }
    }
}
