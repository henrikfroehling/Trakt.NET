namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class SyncRatingsPostResponseNotFoundShowJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundShow>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundShow> CreateObjectReader() => new TraktSyncRatingsPostResponseNotFoundShowObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundShow> CreateArrayReader() => new SyncRatingsPostResponseNotFoundShowArrayJsonReader();
    }
}
