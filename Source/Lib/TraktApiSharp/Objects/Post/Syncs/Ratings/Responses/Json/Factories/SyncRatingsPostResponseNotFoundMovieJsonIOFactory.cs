namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;

    internal class SyncRatingsPostResponseNotFoundMovieJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundMovie>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateObjectReader() => new SyncRatingsPostResponseNotFoundMovieObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundMovie> CreateArrayReader() => new SyncRatingsPostResponseNotFoundMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostResponseNotFoundMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncRatingsPostResponseNotFoundMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
