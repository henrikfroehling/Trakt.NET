namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserCommentJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserComment>
    {
        public ITraktObjectJsonReader<ITraktUserComment> CreateObjectReader() => new TraktUserCommentObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserComment> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserComment)} is not supported.");
        }
    }
}
