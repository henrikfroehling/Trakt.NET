namespace TraktApiSharp.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncCollectionPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostShowSeason>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostShowSeason> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncCollectionPostShowSeason)} is not supported.");

        public IArrayJsonReader<ITraktSyncCollectionPostShowSeason> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPostShowSeason)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCollectionPostShowSeason> CreateObjectWriter() => new SyncCollectionPostShowSeasonObjectJsonWriter();
    }
}
