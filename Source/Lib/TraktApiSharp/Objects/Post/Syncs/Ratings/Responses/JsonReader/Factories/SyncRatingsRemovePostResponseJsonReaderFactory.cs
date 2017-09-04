namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class SyncRatingsRemovePostResponseJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncRatingsRemovePostResponse> CreateObjectReader() => new TraktSyncRatingsRemovePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsRemovePostResponse)} is not supported.");
        }
    }
}
