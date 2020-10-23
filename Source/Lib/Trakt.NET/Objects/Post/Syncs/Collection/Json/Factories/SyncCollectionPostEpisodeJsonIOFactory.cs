namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncCollectionPostEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostEpisode>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostEpisode> CreateObjectReader() => new SyncCollectionPostEpisodeObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncCollectionPostEpisode> CreateObjectWriter() => new SyncCollectionPostEpisodeObjectJsonWriter();
    }
}
