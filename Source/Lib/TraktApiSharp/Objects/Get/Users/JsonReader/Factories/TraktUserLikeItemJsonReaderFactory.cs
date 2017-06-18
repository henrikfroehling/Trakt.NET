namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserLikeItemJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserLikeItem>
    {
        public ITraktObjectJsonReader<ITraktUserLikeItem> CreateObjectReader() => new TraktUserLikeItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserLikeItem> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserLikeItem)} is not supported.");
        }
    }
}
