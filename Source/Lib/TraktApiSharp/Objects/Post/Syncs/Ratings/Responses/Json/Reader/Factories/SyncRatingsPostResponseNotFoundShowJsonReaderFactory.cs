namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories.Reader
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;

    internal class SyncRatingsPostResponseNotFoundShowJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundShow>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundShow> CreateObjectReader() => new SyncRatingsPostResponseNotFoundShowObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundShow> CreateArrayReader() => new SyncRatingsPostResponseNotFoundShowArrayJsonReader();
    }
}
