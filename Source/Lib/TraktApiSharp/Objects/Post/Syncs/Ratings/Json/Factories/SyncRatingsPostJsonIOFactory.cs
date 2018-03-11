namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncRatingsPostJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPost>
    {
        public IObjectJsonReader<ITraktSyncRatingsPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncRatingsPost)} is not supported.");

        public IArrayJsonReader<ITraktSyncRatingsPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPost)} is not supported.");

        public IObjectJsonWriter<ITraktSyncRatingsPost> CreateObjectWriter() => new SyncRatingsPostObjectJsonWriter();
    }
}
