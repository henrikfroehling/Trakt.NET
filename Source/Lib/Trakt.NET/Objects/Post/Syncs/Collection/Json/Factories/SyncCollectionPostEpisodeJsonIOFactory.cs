namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncCollectionPostEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostEpisode>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostEpisode> CreateObjectReader() => new SyncCollectionPostEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionPostEpisode> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPostEpisode)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCollectionPostEpisode> CreateObjectWriter() => new SyncCollectionPostEpisodeObjectJsonWriter();
    }
}
