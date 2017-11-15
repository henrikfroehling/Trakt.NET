namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using System;

    internal class SyncRatingsPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponse>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponse> CreateObjectReader() => new SyncRatingsPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostResponse)} is not supported.");
        }
    }
}
