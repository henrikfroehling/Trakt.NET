namespace TraktApiSharp.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncCollectionPostMovieJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostMovie>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostMovie> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncCollectionPostMovie)} is not supported.");

        public IArrayJsonReader<ITraktSyncCollectionPostMovie> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncCollectionPostMovie)} is not supported.");

        public IObjectJsonWriter<ITraktSyncCollectionPostMovie> CreateObjectWriter() => new SyncCollectionPostMovieObjectJsonWriter();
    }
}
