namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponse>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponse> CreateObjectReader() => new SyncRatingsPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponse> CreateArrayReader() => new SyncRatingsPostResponseArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostResponse> CreateObjectWriter() => new SyncRatingsPostResponseObjectJsonWriter();
    }
}
