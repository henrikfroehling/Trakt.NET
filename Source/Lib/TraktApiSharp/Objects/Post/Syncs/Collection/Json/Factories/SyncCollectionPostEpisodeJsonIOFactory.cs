namespace TraktApiSharp.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncCollectionPostEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostEpisode>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostEpisode> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncCollectionPostEpisode)} is not supported.");

        public IArrayJsonReader<ITraktSyncCollectionPostEpisode> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPostEpisode)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCollectionPostEpisode> CreateObjectWriter() => new SyncCollectionPostEpisodeObjectJsonWriter();
    }
}
