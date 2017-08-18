namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSyncRatingsPostResponseNotFoundShowJsonReaderFactory : IJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundShow>
    {
        public ITraktObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundShow> CreateObjectReader() => new TraktSyncRatingsPostResponseNotFoundShowObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundShow> CreateArrayReader() => new TraktSyncRatingsPostResponseNotFoundShowArrayJsonReader();
    }
}
