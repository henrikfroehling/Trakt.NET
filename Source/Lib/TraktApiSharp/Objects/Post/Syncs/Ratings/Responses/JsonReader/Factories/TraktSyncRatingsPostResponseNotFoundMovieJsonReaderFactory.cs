namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSyncRatingsPostResponseNotFoundMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundMovie>
    {
        public ITraktObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateObjectReader() => new TraktSyncRatingsPostResponseNotFoundMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateArrayReader() => new TraktSyncRatingsPostResponseNotFoundMovieArrayJsonReader();
    }
}
