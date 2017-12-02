namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;
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
