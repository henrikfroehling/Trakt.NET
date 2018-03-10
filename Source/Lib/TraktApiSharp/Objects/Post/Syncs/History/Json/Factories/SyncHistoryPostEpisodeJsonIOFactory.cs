namespace TraktApiSharp.Objects.Post.Syncs.History.Json.Factories
{
    using System;
    using TraktApiSharp.Objects.Json;
    using Writer;

    internal class SyncHistoryPostEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostEpisode>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostEpisode> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncHistoryPostEpisode)} is not supported.");

        public IArrayJsonReader<ITraktSyncHistoryPostEpisode> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryPostEpisode)} is not supported.");

        public IObjectJsonWriter<ITraktSyncHistoryPostEpisode> CreateObjectWriter() => new SyncHistoryPostEpisodeObjectJsonWriter();
    }
}
