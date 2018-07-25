namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncCollectionPostMovieJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostMovie>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostMovie> CreateObjectReader() => new SyncCollectionPostMovieObjectJsonReader();

        public IArrayJsonReader<ITraktSyncCollectionPostMovie> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPostMovie)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCollectionPostMovie> CreateObjectWriter() => new SyncCollectionPostMovieObjectJsonWriter();
    }
}
