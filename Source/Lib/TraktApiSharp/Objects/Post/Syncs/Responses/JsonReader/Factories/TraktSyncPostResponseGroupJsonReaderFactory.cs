namespace TraktApiSharp.Objects.Post.Syncs.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncPostResponseGroupJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncPostResponseGroup>
    {
        public ITraktObjectJsonReader<ITraktSyncPostResponseGroup> CreateObjectReader() => new TraktSyncPostResponseGroupObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncPostResponseGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncPostResponseGroup)} is not supported.");
        }
    }
}
