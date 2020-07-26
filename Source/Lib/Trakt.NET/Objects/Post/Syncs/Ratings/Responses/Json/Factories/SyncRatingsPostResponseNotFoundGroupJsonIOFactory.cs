namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup> CreateObjectReader()
            => new SyncRatingsPostResponseNotFoundGroupObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostResponseNotFoundGroup> CreateObjectWriter()
            => new SyncRatingsPostResponseNotFoundGroupObjectJsonWriter();
    }
}
