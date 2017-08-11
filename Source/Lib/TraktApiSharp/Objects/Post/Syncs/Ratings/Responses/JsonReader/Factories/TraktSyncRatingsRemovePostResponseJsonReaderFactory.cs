namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncRatingsRemovePostResponseJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncRatingsRemovePostResponse>
    {
        public ITraktObjectJsonReader<ITraktSyncRatingsRemovePostResponse> CreateObjectReader() => new TraktSyncRatingsRemovePostResponseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncRatingsRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsRemovePostResponse)} is not supported.");
        }
    }
}
