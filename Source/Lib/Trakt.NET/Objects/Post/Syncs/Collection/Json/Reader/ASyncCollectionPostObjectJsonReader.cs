namespace TraktNet.Objects.Post.Syncs.Collection.Json.Reader
{
    using Newtonsoft.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Json;

    internal abstract class ASyncCollectionPostObjectJsonReader<TSyncCollectionPost> : AObjectJsonReader<TSyncCollectionPost>
        where TSyncCollectionPost : ITraktSyncCollectionPost
    {
        public override async Task<TSyncCollectionPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                TSyncCollectionPost traktSyncCollectionPost = Activator.CreateInstance<TSyncCollectionPost>();
                var syncCollectionPostMovieArrayJsonReader = new ArrayJsonReader<ITraktSyncCollectionPostMovie>();
                var syncCollectionPostShowArrayJsonReader = new ArrayJsonReader<ITraktSyncCollectionPostShow>();
                var syncCollectionPostSeasonArrayJsonReader = new ArrayJsonReader<ITraktSyncCollectionPostSeason>();
                var syncCollectionPostEpisodeArrayJsonReader = new ArrayJsonReader<ITraktSyncCollectionPostEpisode>();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            traktSyncCollectionPost.Movies = await syncCollectionPostMovieArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            traktSyncCollectionPost.Shows = await syncCollectionPostShowArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            traktSyncCollectionPost.Seasons = await syncCollectionPostSeasonArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            traktSyncCollectionPost.Episodes = await syncCollectionPostEpisodeArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSyncCollectionPost;
            }

            return await Task.FromResult(default(TSyncCollectionPost));
        }
    }
}
