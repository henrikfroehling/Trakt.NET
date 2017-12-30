namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;
    using System;

    internal class SyncRatingsPostResponseNotFoundGroupJsonReaderFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup> CreateObjectReader() => new SyncRatingsPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostResponseNotFoundGroup)} is not supported.");
        }

        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
