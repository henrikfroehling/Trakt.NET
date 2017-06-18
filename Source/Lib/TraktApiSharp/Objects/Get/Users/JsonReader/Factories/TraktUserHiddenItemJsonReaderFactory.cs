namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserHiddenItemJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserHiddenItem>
    {
        public ITraktObjectJsonReader<ITraktUserHiddenItem> CreateObjectReader() => new TraktUserHiddenItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserHiddenItem> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserHiddenItem)} is not supported.");
        }
    }
}
