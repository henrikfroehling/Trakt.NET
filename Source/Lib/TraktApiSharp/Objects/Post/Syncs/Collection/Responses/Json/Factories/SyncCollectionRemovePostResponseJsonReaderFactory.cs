namespace TraktApiSharp.Objects.Post.Syncs.Collection.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Collection.Responses.Json.Reader;
    using System;

    internal class SyncCollectionRemovePostResponseJsonReaderFactory : IJsonIOFactory<ITraktSyncCollectionRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncCollectionRemovePostResponse> CreateObjectReader() => new SyncCollectionRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionRemovePostResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncCollectionRemovePostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncCollectionRemovePostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
