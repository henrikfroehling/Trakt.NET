namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;

    internal class SyncRatingsPostResponseNotFoundMovieJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundMovie>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateObjectReader() => new SyncRatingsPostResponseNotFoundMovieObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateArrayReader() => new SyncRatingsPostResponseNotFoundMovieArrayJsonReader();
    }
}
