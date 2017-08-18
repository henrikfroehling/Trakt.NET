namespace TraktApiSharp.Objects.Post.Syncs.Collection.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncCollectionRemovePostResponseJsonReaderFactory : IJsonReaderFactory<ITraktSyncCollectionRemovePostResponse>
    {
        public ITraktObjectJsonReader<ITraktSyncCollectionRemovePostResponse> CreateObjectReader() => new TraktSyncCollectionRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionRemovePostResponse)} is not supported.");
        }
    }
}
