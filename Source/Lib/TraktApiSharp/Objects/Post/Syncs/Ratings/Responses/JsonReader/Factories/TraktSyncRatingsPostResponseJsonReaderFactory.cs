namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncRatingsPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponse>
    {
        public ITraktObjectJsonReader<ITraktSyncRatingsPostResponse> CreateObjectReader() => new TraktSyncRatingsPostResponseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncRatingsPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostResponse)} is not supported.");
        }
    }
}
