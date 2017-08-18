namespace TraktApiSharp.Objects.Post.Syncs.Collection.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncCollectionPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktSyncCollectionPostResponse>
    {
        public ITraktObjectJsonReader<ITraktSyncCollectionPostResponse> CreateObjectReader() => new TraktSyncCollectionPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPostResponse)} is not supported.");
        }
    }
}
