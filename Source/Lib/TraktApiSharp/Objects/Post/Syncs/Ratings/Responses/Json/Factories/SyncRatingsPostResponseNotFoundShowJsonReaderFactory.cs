namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;

    internal class SyncRatingsPostResponseNotFoundShowJsonReaderFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundShow>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundShow> CreateObjectReader() => new SyncRatingsPostResponseNotFoundShowObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundShow> CreateArrayReader() => new SyncRatingsPostResponseNotFoundShowArrayJsonReader();

        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
