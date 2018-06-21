namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Reader;
    using System;
    using Writer;

    internal class SyncRatingsPostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup> CreateObjectReader()
            => new SyncRatingsPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostResponseNotFoundGroup)} is not supported.");

        public IObjectJsonWriter<ITraktSyncRatingsPostResponseNotFoundGroup> CreateObjectWriter()
            => new SyncRatingsPostResponseNotFoundGroupObjectJsonWriter();
    }
}
