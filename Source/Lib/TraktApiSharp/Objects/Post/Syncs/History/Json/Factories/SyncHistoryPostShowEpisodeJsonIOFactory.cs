namespace TraktApiSharp.Objects.Post.Syncs.History.Json.Factories
{
    using System;
    using TraktApiSharp.Objects.Json;
    using Writer;

    internal class SyncHistoryPostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostShowEpisode>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostShowEpisode> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncHistoryPostShowEpisode)} is not supported.");

        public IArrayJsonReader<ITraktSyncHistoryPostShowEpisode> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryPostShowEpisode)} is not supported.");

        public IObjectJsonWriter<ITraktSyncHistoryPostShowEpisode> CreateObjectWriter() => new SyncHistoryPostShowEpisodeObjectJsonWriter();
    }
}
