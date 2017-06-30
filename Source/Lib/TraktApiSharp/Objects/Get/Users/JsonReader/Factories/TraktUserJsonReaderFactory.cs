namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserJsonReaderFactory : ITraktJsonReaderFactory<ITraktUser>
    {
        public ITraktObjectJsonReader<ITraktUser> CreateObjectReader() => new TraktUserObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUser> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUser)} is not supported.");
        }
    }
}
