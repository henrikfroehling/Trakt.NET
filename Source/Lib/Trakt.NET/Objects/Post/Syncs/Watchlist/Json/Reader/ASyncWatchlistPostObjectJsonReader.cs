namespace TraktNet.Objects.Post.Syncs.Watchlist.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Json;

    internal abstract class ASyncWatchlistPostObjectJsonReader<TSyncWatchlistPost> : AObjectJsonReader<TSyncWatchlistPost>
        where TSyncWatchlistPost : ITraktSyncWatchlistPost
    {
        public override async Task<TSyncWatchlistPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                TSyncWatchlistPost syncWatchlistPost = CreateInstance();
                var movieArrayJsonReader = new ArrayJsonReader<ITraktSyncWatchlistPostMovie>();
                var showArrayJsonReader = new ArrayJsonReader<ITraktSyncWatchlistPostShow>();
                var seasonArrayJsonReader = new ArrayJsonReader<ITraktSyncWatchlistPostSeason>();
                var episodeArrayJsonReader = new ArrayJsonReader<ITraktSyncWatchlistPostEpisode>();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            syncWatchlistPost.Movies = await movieArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            syncWatchlistPost.Shows = await showArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASON:
                            syncWatchlistPost.Seasons = await seasonArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            syncWatchlistPost.Episodes = await episodeArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncWatchlistPost;
            }

            return await Task.FromResult(default(TSyncWatchlistPost));
        }

        protected abstract TSyncWatchlistPost CreateInstance();
    }
}
