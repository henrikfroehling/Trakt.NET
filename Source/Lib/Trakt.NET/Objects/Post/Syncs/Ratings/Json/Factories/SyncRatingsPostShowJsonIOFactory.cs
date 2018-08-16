namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncRatingsPostShowJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostShow>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostShow> CreateObjectReader() => new SyncRatingsPostShowObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostShow> CreateArrayReader() => new SyncRatingsPostShowArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostShow> CreateObjectWriter() => new SyncRatingsPostShowObjectJsonWriter();
    }
}
