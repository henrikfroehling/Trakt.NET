namespace TraktNet.Objects.Post.Syncs.Collection.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncCollectionRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncCollectionRemovePostResponse> CreateObjectReader() => new SyncCollectionRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionRemovePostResponse> CreateArrayReader() => new SyncCollectionRemovePostResponseArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncCollectionRemovePostResponse> CreateObjectWriter() => new SyncCollectionRemovePostResponseObjectJsonWriter();
    }
}
