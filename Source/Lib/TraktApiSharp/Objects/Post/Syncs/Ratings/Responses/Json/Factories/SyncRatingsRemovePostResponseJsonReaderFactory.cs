namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using System;

    internal class SyncRatingsRemovePostResponseJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncRatingsRemovePostResponse> CreateObjectReader() => new SyncRatingsRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsRemovePostResponse)} is not supported.");
        }
    }
}
