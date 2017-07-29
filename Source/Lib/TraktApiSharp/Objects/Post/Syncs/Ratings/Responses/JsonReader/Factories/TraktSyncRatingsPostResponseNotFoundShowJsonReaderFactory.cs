namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSyncRatingsPostResponseNotFoundShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktSyncRatingsPostResponseNotFoundShow>
    {
        public ITraktObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundShow> CreateObjectReader() => new TraktSyncRatingsPostResponseNotFoundShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundShow> CreateArrayReader() => new TraktSyncRatingsPostResponseNotFoundShowArrayJsonReader();
    }
}
