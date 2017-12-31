namespace TraktApiSharp.Objects.Post.Syncs.Collection.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Collection.Responses.Json.Reader;
    using System;

    internal class SyncCollectionRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncCollectionRemovePostResponse> CreateObjectReader() => new SyncCollectionRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionRemovePostResponse)} is not supported.");
        }

        public IObjectJsonWriter<ITraktSyncCollectionRemovePostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncCollectionRemovePostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
