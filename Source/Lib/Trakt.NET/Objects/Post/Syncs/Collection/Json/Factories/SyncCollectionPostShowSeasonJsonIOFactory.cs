namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncCollectionPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostShowSeason>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostShowSeason> CreateObjectReader() => new SyncCollectionPostShowSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionPostShowSeason> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPostShowSeason)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCollectionPostShowSeason> CreateObjectWriter() => new SyncCollectionPostShowSeasonObjectJsonWriter();
    }
}
