namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;

    internal class SyncRatingsPostResponseNotFoundMovieJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundMovie>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateObjectReader() => new SyncRatingsPostResponseNotFoundMovieObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateArrayReader() => new SyncRatingsPostResponseNotFoundMovieArrayJsonReader();
    }
}
