namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncRatingsPostShowJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostShow>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostShow> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncRatingsPostShow)} is not supported.");

        public IArrayJsonReader<ITraktSyncRatingsPostShow> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostShow)} is not supported.");

        public IObjectJsonWriter<ITraktSyncRatingsPostShow> CreateObjectWriter() => new SyncRatingsPostShowObjectJsonWriter();
    }
}
