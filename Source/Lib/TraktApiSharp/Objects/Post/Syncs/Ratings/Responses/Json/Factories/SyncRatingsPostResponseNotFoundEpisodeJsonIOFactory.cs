namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.Ratings.Responses.Json.Reader;

    internal class SyncRatingsPostResponseNotFoundEpisodeJsonIOFactory : IJsonIOFactory<ITraktSyncRatingsPostResponseNotFoundEpisode>
    {
        public IObjectJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateObjectReader() => new SyncRatingsPostResponseNotFoundEpisodeObjectJsonReader();

        public IArrayJsonReader<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateArrayReader() => new SyncRatingsPostResponseNotFoundEpisodeArrayJsonReader();

        public IObjectJsonWriter<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncRatingsPostResponseNotFoundEpisode> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
