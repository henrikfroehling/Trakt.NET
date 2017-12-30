namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;

    internal class SyncRatingsPostResponseNotFoundEpisodeJsonReaderFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundEpisode>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateObjectReader() => new SyncRatingsPostResponseNotFoundEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateArrayReader() => new SyncRatingsPostResponseNotFoundEpisodeArrayJsonReader();

        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
