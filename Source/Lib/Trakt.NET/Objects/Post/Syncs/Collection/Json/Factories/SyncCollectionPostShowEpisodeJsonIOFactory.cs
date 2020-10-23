namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncCollectionPostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostShowEpisode>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostShowEpisode> CreateObjectReader() => new SyncCollectionPostShowEpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncCollectionPostShowEpisode> CreateObjectWriter() => new SyncCollectionPostShowEpisodeObjectJsonWriter();
    }
}
