namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncRatingsPostShowEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostShowEpisode>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostShowEpisode> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncRatingsPostShowEpisode)} is not supported.");

        public IArrayJsonReader<ITraktSyncRatingsPostShowEpisode> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostShowEpisode)} is not supported.");

        public IObjectJsonWriter<ITraktSyncRatingsPostShowEpisode> CreateObjectWriter() => new SyncRatingsPostShowEpisodeObjectJsonWriter();
    }
}
