namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSyncRatingsPostResponseNotFoundMovieJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundMovie>
    {
        public ITraktObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateObjectReader() => new TraktSyncRatingsPostResponseNotFoundMovieObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateArrayReader() => new TraktSyncRatingsPostResponseNotFoundMovieArrayJsonReader();
    }
}
