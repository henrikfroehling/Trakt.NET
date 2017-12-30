namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;

    internal class SyncRatingsPostResponseNotFoundMovieJsonReaderFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundMovie>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateObjectReader() => new SyncRatingsPostResponseNotFoundMovieObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateArrayReader() => new SyncRatingsPostResponseNotFoundMovieArrayJsonReader();

        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
