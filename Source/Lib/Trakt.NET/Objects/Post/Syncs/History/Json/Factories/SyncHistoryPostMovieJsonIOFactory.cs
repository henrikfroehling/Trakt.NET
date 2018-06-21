namespace TraktNet.Objects.Post.Syncs.History.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncHistoryPostMovieJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryPostMovie>
    {
        public IObjectJsonReader<ITraktSyncHistoryPostMovie> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncHistoryPostMovie)} is not supported.");

        public IArrayJsonReader<ITraktSyncHistoryPostMovie> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryPostMovie)} is not supported.");

        public IObjectJsonWriter<ITraktSyncHistoryPostMovie> CreateObjectWriter() => new SyncHistoryPostMovieObjectJsonWriter();
    }
}
