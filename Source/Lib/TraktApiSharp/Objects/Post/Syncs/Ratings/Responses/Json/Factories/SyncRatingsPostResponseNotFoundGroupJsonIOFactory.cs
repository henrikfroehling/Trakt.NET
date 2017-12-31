namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;
    using System;

    internal class SyncRatingsPostResponseNotFoundGroupJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup> CreateObjectReader() => new SyncRatingsPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostResponseNotFoundGroup)} is not supported.");
        }

        public IObjectJsonWriter<ITraktSyncRatingsPostResponseNotFoundGroup> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncRatingsPostResponseNotFoundGroup> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
