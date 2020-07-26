namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponse>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponse> CreateObjectReader() => new SyncRatingsPostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostResponse> CreateObjectWriter() => new SyncRatingsPostResponseObjectJsonWriter();
    }
}
