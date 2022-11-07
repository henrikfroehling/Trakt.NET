namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Syncs.History.Json.Reader;
    using TraktNet.Objects.Post.Syncs.History.Json.Writer;

    internal class SyncHistoryRemovePostMovieJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostMovie>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostMovie> CreateObjectReader() => new SyncHistoryRemovePostMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncHistoryRemovePostMovie> CreateObjectWriter() => new SyncHistoryRemovePostMovieObjectJsonWriter();
    }
}
