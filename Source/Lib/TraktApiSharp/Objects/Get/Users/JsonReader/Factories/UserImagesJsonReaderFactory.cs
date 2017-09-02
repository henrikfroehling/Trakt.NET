namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class UserImagesJsonReaderFactory : IJsonReaderFactory<ITraktUserImages>
    {
        public IObjectJsonReader<ITraktUserImages> CreateObjectReader() => new TraktUserImagesObjectJsonReader();

        public IArrayJsonReader<ITraktUserImages> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserImages)} is not supported.");
        }
    }
}
