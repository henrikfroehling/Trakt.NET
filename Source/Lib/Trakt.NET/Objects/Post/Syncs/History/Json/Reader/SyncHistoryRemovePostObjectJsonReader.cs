namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncHistoryRemovePostObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryRemovePost>
    {
        public override async Task<ITraktSyncHistoryRemovePost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncHistoryRemovePost));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieArrayJsonReader = new SyncHistoryPostMovieArrayJsonReader();
                var showArrayJsonReader = new SyncHistoryPostShowArrayJsonReader();
                var episodeArrayJsonReader = new SyncHistoryPostEpisodeArrayJsonReader();
                ITraktSyncHistoryRemovePost syncHistoryRemovePost = new TraktSyncHistoryRemovePost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_HISTORY_POST_PROPERTY_NAME_MOVIES:
                            syncHistoryRemovePost.Movies = await movieArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_HISTORY_POST_PROPERTY_NAME_SHOWS:
                            syncHistoryRemovePost.Shows = await showArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_HISTORY_POST_PROPERTY_NAME_EPISODES:
                            syncHistoryRemovePost.Episodes = await episodeArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SYNC_HISTORY_REMOVE_POST_PROPERTY_NAME_IDS:
                            syncHistoryRemovePost.HistoryIds = await JsonReaderHelper.ReadUnsignedLongArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryRemovePost;
            }

            return await Task.FromResult(default(ITraktSyncHistoryRemovePost));
        }
    }
}
