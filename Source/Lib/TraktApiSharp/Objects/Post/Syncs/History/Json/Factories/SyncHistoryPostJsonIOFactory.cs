namespace TraktApiSharp.Objects.Post.Syncs.History.Json.Factories
{
    using System;
    using TraktApiSharp.Objects.Json;
    using Writer;

    internal class SyncHistoryPostJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPost>
    {
        public IObjectJsonReader<ITraktSyncHistoryPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncHistoryPost)} is not supported.");

        public IArrayJsonReader<ITraktSyncHistoryPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryPost)} is not supported.");

        public IObjectJsonWriter<ITraktSyncHistoryPost> CreateObjectWriter() => new SyncHistoryPostObjectJsonWriter();
    }
}
