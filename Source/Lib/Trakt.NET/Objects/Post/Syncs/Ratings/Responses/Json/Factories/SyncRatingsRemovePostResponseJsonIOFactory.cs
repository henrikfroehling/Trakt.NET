namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsRemovePostResponseJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsRemovePostResponse>
    {
        public IObjectJsonReader<ITraktSyncRatingsRemovePostResponse> CreateObjectReader()
            => new SyncRatingsRemovePostResponseObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsRemovePostResponse> CreateObjectWriter()
            => new SyncRatingsRemovePostResponseObjectJsonWriter();
    }
}
