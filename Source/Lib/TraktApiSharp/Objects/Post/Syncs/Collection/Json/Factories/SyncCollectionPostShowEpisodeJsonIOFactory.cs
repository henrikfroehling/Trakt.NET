namespace TraktApiSharp.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncCollectionPostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostShowEpisode>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostShowEpisode> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncCollectionPostShowEpisode)} is not supported.");

        public IArrayJsonReader<ITraktSyncCollectionPostShowEpisode> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPostShowEpisode)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCollectionPostShowEpisode> CreateObjectWriter() => new SyncCollectionPostShowEpisodeObjectJsonWriter();
    }
}
