namespace TraktApiSharp.Objects.Post.Syncs.History.Json.Factories
{
    using System;
    using TraktApiSharp.Objects.Json;
    using Writer;

    internal class SyncHistoryPostShowJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostShow>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostShow> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncHistoryPostShow)} is not supported.");

        public IArrayJsonReader<ITraktSyncHistoryPostShow> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryPostShow)} is not supported.");

        public IObjectJsonWriter<ITraktSyncHistoryPostShow> CreateObjectWriter() => new SyncHistoryPostShowObjectJsonWriter();
    }
}
