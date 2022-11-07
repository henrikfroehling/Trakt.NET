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
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieArrayJsonReader = new ArrayJsonReader<ITraktSyncHistoryRemovePostMovie>();
                var showArrayJsonReader = new ArrayJsonReader<ITraktSyncHistoryRemovePostShow>();
                var seasonArrayJsonReader = new ArrayJsonReader<ITraktSyncHistoryRemovePostSeason>();
                var episodeArrayJsonReader = new ArrayJsonReader<ITraktSyncHistoryRemovePostEpisode>();
                ITraktSyncHistoryRemovePost syncHistoryRemovePost = new TraktSyncHistoryRemovePost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            syncHistoryRemovePost.Movies = await movieArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            syncHistoryRemovePost.Shows = await showArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            syncHistoryRemovePost.Seasons = await seasonArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            syncHistoryRemovePost.Episodes = await episodeArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_IDS:
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
