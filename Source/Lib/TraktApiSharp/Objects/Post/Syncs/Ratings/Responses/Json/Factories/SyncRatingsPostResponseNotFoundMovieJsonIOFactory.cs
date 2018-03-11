namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostResponseNotFoundMovieJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundMovie>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateObjectReader()
            => new SyncRatingsPostResponseNotFoundMovieObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateArrayReader()
            => new SyncRatingsPostResponseNotFoundMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostResponseNotFoundMovie> CreateObjectWriter()
            => new SyncRatingsPostResponseNotFoundMovieObjectJsonWriter();
    }
}
