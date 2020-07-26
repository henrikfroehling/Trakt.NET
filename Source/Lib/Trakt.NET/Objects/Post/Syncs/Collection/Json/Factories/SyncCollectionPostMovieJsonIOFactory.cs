namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncCollectionPostMovieJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostMovie>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostMovie> CreateObjectReader() => new SyncCollectionPostMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncCollectionPostMovie> CreateObjectWriter() => new SyncCollectionPostMovieObjectJsonWriter();
    }
}
