namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktSyncRatingsPostResponseNotFoundGroupJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundGroup>
    {
        public ITraktObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup> CreateObjectReader() => new TraktSyncRatingsPostResponseNotFoundGroupObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncRatingsPostResponseNotFoundGroup)} is not supported.");
        }
    }
}
