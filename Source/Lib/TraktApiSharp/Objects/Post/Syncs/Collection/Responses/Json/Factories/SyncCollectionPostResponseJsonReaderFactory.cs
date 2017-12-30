namespace TraktApiSharp.Objects.Post.Syncs.Collection.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Collection.Responses.Json.Reader;
    using System;

    internal class SyncCollectionPostResponseJsonReaderFactory : IJsonIOFactory<ITraktSyncCollectionPostResponse>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostResponse> CreateObjectReader() => new SyncCollectionPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPostResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncCollectionPostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncCollectionPostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
