namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserImagesJsonReaderFactory : IJsonReaderFactory<ITraktUserImages>
    {
        public ITraktObjectJsonReader<ITraktUserImages> CreateObjectReader() => new TraktUserImagesObjectJsonReader();

        public IArrayJsonReader<ITraktUserImages> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserImages)} is not supported.");
        }
    }
}
