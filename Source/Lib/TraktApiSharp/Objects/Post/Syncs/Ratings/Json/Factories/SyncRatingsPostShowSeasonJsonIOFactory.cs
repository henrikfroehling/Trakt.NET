namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncRatingsPostShowSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostShowSeason>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostShowSeason> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncRatingsPostShowSeason)} is not supported.");

        public IArrayJsonReader<ITraktSyncRatingsPostShowSeason> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostShowSeason)} is not supported.");

        public IObjectJsonWriter<ITraktSyncRatingsPostShowSeason> CreateObjectWriter() => new SyncRatingsPostShowSeasonObjectJsonWriter();
    }
}
