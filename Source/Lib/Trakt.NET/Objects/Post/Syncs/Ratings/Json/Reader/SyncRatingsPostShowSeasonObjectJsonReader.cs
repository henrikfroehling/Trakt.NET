namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncRatingsPostShowSeasonObjectJsonReader : AObjectJsonReader<ITraktSyncRatingsPostShowSeason>
    {
        public override async Task<ITraktSyncRatingsPostShowSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeArrayJsonReader = new ArrayJsonReader<ITraktSyncRatingsPostShowEpisode>();
                ITraktSyncRatingsPostShowSeason syncRatingsPostShow = new TraktSyncRatingsPostShowSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_NUMBER:
                            {
                                Pair<bool, int> value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncRatingsPostShow.Number = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_RATING:
                            {
                                Pair<bool, int> value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncRatingsPostShow.Rating = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_RATED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncRatingsPostShow.RatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            syncRatingsPostShow.Episodes = await episodeArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRatingsPostShow;
            }

            return await Task.FromResult(default(ITraktSyncRatingsPostShowSeason));
        }
    }
}
