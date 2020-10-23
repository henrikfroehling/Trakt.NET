namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncHistoryPostMovieJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostMovie>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostMovie> CreateObjectReader() => new SyncHistoryPostMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryPostMovie> CreateObjectWriter() => new SyncHistoryPostMovieObjectJsonWriter();
    }
}
