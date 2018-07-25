namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncCollectionPostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostShowEpisode>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostShowEpisode> CreateObjectReader() => new SyncCollectionPostShowEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionPostShowEpisode> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPostShowEpisode)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCollectionPostShowEpisode> CreateObjectWriter() => new SyncCollectionPostShowEpisodeObjectJsonWriter();
    }
}
