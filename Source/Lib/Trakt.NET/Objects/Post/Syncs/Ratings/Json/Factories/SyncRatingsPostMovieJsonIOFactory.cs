namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostMovieJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostMovie>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostMovie> CreateObjectReader() => new SyncRatingsPostMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostMovie> CreateObjectWriter() => new SyncRatingsPostMovieObjectJsonWriter();
    }
}
