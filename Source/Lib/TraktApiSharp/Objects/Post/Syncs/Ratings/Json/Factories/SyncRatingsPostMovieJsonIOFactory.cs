namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SyncRatingsPostMovieJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostMovie>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostMovie> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSyncRatingsPostMovie)} is not supported.");

        public IArrayJsonReader<ITraktSyncRatingsPostMovie> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostMovie)} is not supported.");

        public IObjectJsonWriter<ITraktSyncRatingsPostMovie> CreateObjectWriter() => new SyncRatingsPostMovieObjectJsonWriter();
    }
}
