namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostResponseNotFoundMovieJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundMovie>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateObjectReader()
            => new SyncRatingsPostResponseNotFoundMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostResponseNotFoundMovie> CreateObjectWriter()
            => new SyncRatingsPostResponseNotFoundMovieObjectJsonWriter();
    }
}
