namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;
    using System;

    internal class SyncRatingsRemovePostResponseJsonReaderFactory : IJsonIOFactory<ITraktSyncRatingsRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncRatingsRemovePostResponse> CreateObjectReader() => new SyncRatingsRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsRemovePostResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncRatingsRemovePostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncRatingsRemovePostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
