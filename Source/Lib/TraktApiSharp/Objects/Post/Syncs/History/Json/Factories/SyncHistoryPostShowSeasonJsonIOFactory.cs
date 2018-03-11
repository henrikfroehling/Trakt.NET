namespace TraktApiSharp.Objects.Post.Syncs.History.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncHistoryPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostShowSeason>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostShowSeason> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncHistoryPostShowSeason)} is not supported.");

        public IArrayJsonReader<ITraktSyncHistoryPostShowSeason> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryPostShowSeason)} is not supported.");

        public IObjectJsonWriter<ITraktSyncHistoryPostShowSeason> CreateObjectWriter() => new SyncHistoryPostShowSeasonObjectJsonWriter();
    }
}
