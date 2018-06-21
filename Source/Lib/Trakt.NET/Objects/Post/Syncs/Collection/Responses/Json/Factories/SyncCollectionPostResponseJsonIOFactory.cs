namespace TraktNet.Objects.Post.Syncs.Collection.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncCollectionPostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostResponse>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostResponse> CreateObjectReader() => new SyncCollectionPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionPostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCollectionPostResponse> CreateObjectWriter() => new SyncCollectionPostResponseObjectJsonWriter();
    }
}
