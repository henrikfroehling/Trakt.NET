namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktCommentJsonReaderFactory : ITraktJsonReaderFactory<ITraktComment>
    {
        public ITraktObjectJsonReader<ITraktComment> CreateObjectReader() => new TraktCommentObjectJsonReader();

        public ITraktArrayJsonReader<ITraktComment> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktComment)} is not supported.");
        }
    }
}
