namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncRatingsPostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponse>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponse> CreateObjectReader() => new SyncRatingsPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponse> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostResponse)} is not supported.");

        public IObjectJsonWriter<ITraktSyncRatingsPostResponse> CreateObjectWriter() => new SyncRatingsPostResponseObjectJsonWriter();
    }
}
