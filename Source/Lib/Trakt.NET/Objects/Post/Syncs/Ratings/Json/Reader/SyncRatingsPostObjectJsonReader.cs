namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostObjectJsonReader : AObjectJsonReader<ITraktSyncRatingsPost>
    {
        public override async Task<ITraktSyncRatingsPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieArrayJsonReader = new ArrayJsonReader<ITraktSyncRatingsPostMovie>();
                var showArrayJsonReader = new ArrayJsonReader<ITraktSyncRatingsPostShow>();
                var episodeArrayJsonReader = new ArrayJsonReader<ITraktSyncRatingsPostEpisode>();
                ITraktSyncRatingsPost syncRatingsPost = new TraktSyncRatingsPost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            syncRatingsPost.Movies = await movieArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            syncRatingsPost.Shows = await showArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            syncRatingsPost.Episodes = await episodeArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRatingsPost;
            }

            return await Task.FromResult(default(ITraktSyncRatingsPost));
        }
    }
}
