namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;
    using System;

    internal class SyncRatingsPostResponseJsonReaderFactory : IJsonIOFactory<ITraktSyncRatingsPostResponse>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponse> CreateObjectReader() => new SyncRatingsPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostResponse)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncRatingsPostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncRatingsPostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
