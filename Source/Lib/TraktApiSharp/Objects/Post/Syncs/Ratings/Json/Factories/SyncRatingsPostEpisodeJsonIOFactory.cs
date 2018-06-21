namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncRatingsPostEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostEpisode>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostEpisode> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncRatingsPostEpisode)} is not supported.");

        public IArrayJsonReader<ITraktSyncRatingsPostEpisode> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostEpisode)} is not supported.");

        public IObjectJsonWriter<ITraktSyncRatingsPostEpisode> CreateObjectWriter() => new SyncRatingsPostEpisodeObjectJsonWriter();
    }
}
