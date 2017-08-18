namespace TraktApiSharp.Objects.Post.Syncs.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncPostResponseNotFoundGroupJsonReaderFactory : IJsonReaderFactory<ITraktSyncPostResponseNotFoundGroup>
    {
        public ITraktObjectJsonReader<ITraktSyncPostResponseNotFoundGroup> CreateObjectReader() => new TraktSyncPostResponseNotFoundGroupObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncPostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncPostResponseNotFoundGroup)} is not supported.");
        }
    }
}
