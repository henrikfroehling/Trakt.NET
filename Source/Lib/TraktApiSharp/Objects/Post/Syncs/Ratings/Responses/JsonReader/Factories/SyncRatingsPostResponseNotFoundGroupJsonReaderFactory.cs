namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class SyncRatingsPostResponseNotFoundGroupJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup> CreateObjectReader() => new TraktSyncRatingsPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostResponseNotFoundGroup)} is not supported.");
        }
    }
}
